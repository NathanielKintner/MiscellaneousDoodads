using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LookForLines
{
    public partial class Form1 : Form
    {
        static int MIN_BUMP_SIZE = 7;
        static List<Tuple<Double, Double>> _pts = new List<Tuple<double, double>>();
        static List<Tuple<Double, Double>> _ptsAveraged = new List<Tuple<double, double>>();
        static List<Tuple<Double, Double>> _ptsVolatile = new List<Tuple<double, double>>();
        static List<Tuple<Double, Double>> _ptsNoOutliers = new List<Tuple<double, double>>();
        static List<Tuple<Double, Double>> _ptsFlat = new List<Tuple<double, double>>();
        static List<Tuple<Double, Double>> _ptsMassagedGlobal = new List<Tuple<double, double>>();
        static Dictionary<int, int> _bumps = new Dictionary<int, int>();
        static Dictionary<int, int> _divits = new Dictionary<int, int>();
        static int _bestRow = 0;
        static int _outliers = 0;
        static int _tempOutliers = 0;
        static double _foundNoise = 0.0;
        static int AVERAGE_REACH = 5;
        static List<Label> _tmpLabels = new List<Label>();
        public enum drawforms
        {
            data,
            average,
            flatGuess,
            noOutliers,
            massaged
        }

        public Form1()
        {
            InitializeComponent();
            comboBoxFiles.DataSource = Directory.GetFiles("Datafiles");
            comboBoxDrawOptions.DataSource = Enum.GetNames(typeof(drawforms));
        }

        private void buttonLookForLine_Click(object sender, EventArgs e)
        {
            foreach(Label lbl in _tmpLabels)
            {
                this.Controls.Remove(lbl);
            }
            _outliers = 0;
            _pts = new List<Tuple<double, double>>();
            _ptsAveraged = new List<Tuple<double, double>>();
            _ptsNoOutliers = new List<Tuple<double, double>>();
            _ptsVolatile = new List<Tuple<double, double>>();
            _ptsFlat = new List<Tuple<double, double>>();
            _bumps = new Dictionary<int, int>();
            _divits = new Dictionary<int, int>();
            _pts = getpoints(comboBoxFiles.Text);
            _ptsAveraged = GetAveragePoints(_pts);
            _ptsFlat = findBestFitHorizontal(_pts);
            _ptsNoOutliers = RemoveOutliers(_pts, _ptsAveraged, 15);
            _outliers = _tempOutliers;
            List<Tuple<double, double>> massagedData = new List<Tuple<double, double>>();
            for(int reps = 0; reps < 500; reps++)
            {
                massagedData = Combine(_pts, _ptsAveraged);
                for (int i = 101; i > 1; i -= 5)
                {
                    massagedData = RemoveOutliers(massagedData, GetAveragePoints(massagedData), i);
                }
            }
            _ptsMassagedGlobal = massagedData;
            _foundNoise = (_pts.Count() - _outliers * 1.0) / _pts.Count();
            findIrregularities(_bumps, massagedData, _ptsFlat[0].Item2);
            List<Tuple<double, double>> invertedMassagedData = new List<Tuple<double, double>>();
            foreach(var v in massagedData)
            {
                invertedMassagedData.Add(new Tuple<double, double>(v.Item1, v.Item2 * -1));
            }
            findIrregularities(_divits, invertedMassagedData, _ptsFlat[0].Item2 * -1);
            switch (comboBoxDrawOptions.Text)
            {
                case "data":
                    plotPoints(_pts);
                    break;
                case "average":
                    plotPoints(_ptsAveraged);
                    break;
                case "noOutliers":
                    plotPoints(_ptsNoOutliers);
                    break;
                case "flatGuess":
                    plotPoints(_ptsFlat);
                    break;
                case "massaged":
                    plotPoints(massagedData);
                    break;
                default:
                    break;
            }
            plotBumps(_bumps, Color.Black);
            plotBumps(_divits, Color.LightGray);
            labelDataQuality.Text = "";
            if (_foundNoise < 0.85)
            {
                labelDataQuality.Text = "(Messy)";
            }
            if (_foundNoise < 0.65)
            {
                labelDataQuality.Text = "(Very Messy)";
            }
            if (_foundNoise < 0.45)
            {
                labelDataQuality.Text = "(Likely Useless)";
            }
            labelDataQuality.Text += Math.Round(_foundNoise, 4).ToString();
            
        }


        public static List<Tuple<Double, Double>> getpoints(String str)
        {
            List<Tuple<Double, Double>> ret = new List<Tuple<double, double>>();
            String[] lines = File.ReadAllLines(str);
            foreach (string line in lines)
            {
                String[] xy = line.Split('\t');
                if(xy.Length == 2)
                {
                    ret.Add(new Tuple<double, double>(Convert.ToDouble(xy[0]), Convert.ToDouble(xy[1])));
                }
                
            }
            return ret;
        }

        public void plotPoints(List<Tuple<Double, Double>> toDraw)
        {
            Graphics panelGraphics;
            panelGraphics = panelToDrawOn.CreateGraphics();
            panelGraphics.Clear(Color.White);
            Pen pen = new Pen(Color.Blue);
            SolidBrush sb = new SolidBrush(Color.Red);
            for (int i = 0; i < toDraw.Count - 1; i++)
            {
                Console.WriteLine(toDraw[i].Item1 + "\t" + toDraw[i].Item2);
                Point p1 = new Point((int)(toDraw[i].Item1 * 5), 500 - (int)(toDraw[i].Item2 * 5));
                Point p2 = new Point((int)(toDraw[i + 1].Item1 * 5), 500 - (int)(toDraw[i + 1].Item2 * 5));
                panelGraphics.DrawLine(pen, p1, p2);
                Point drawPoint = new Point(p1.X, p1.Y);
                drawPoint.Offset(-2, -2);
                panelGraphics.FillEllipse(sb, new Rectangle(drawPoint, new Size(5, 5)));
            }
        }

        public void plotBumps(Dictionary<int, int> irregularitites, Color baseColor)
        {
            Graphics panelGraphics;
            panelGraphics = panelToDrawOn.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);
            foreach (int start in irregularitites.Keys)
            {
                Pen pen = new Pen(Color.Green, 3);
                Point p1 = new Point((int)(_ptsAveraged[start].Item1 * 5), 10);
                Point p2 = new Point((int)(_ptsAveraged[start].Item1 * 5), 500);
                panelGraphics.DrawLine(pen, p1, p2);
                pen.Color = Color.Orange;
                Point p3 = new Point((int)(_ptsAveraged[irregularitites[start]].Item1 * 5), 10);
                Point p4 = new Point((int)(_ptsAveraged[irregularitites[start]].Item1 * 5), 500);
                panelGraphics.DrawLine(pen, p3, p4);
                pen.Color = baseColor;
                Point p5 = new Point((int)(_ptsAveraged[start].Item1 * 5), 500 - (int)(_ptsFlat[0].Item2 * 5));
                Point p6 = new Point((int)(_ptsAveraged[irregularitites[start]].Item1 * 5), 500 - (int)(_ptsFlat[0].Item2 * 5));
                panelGraphics.DrawLine(pen, p5, p6);
                double volume = 0;
                for(int i = start; i < irregularitites[start]; i++)
                {
                    volume += (_ptsMassagedGlobal[i + 1].Item1 - _ptsMassagedGlobal[i].Item1) * _ptsMassagedGlobal[i].Item2;
                }
                Label templbl = new Label() { Left = (int)(_ptsAveraged[start].Item1 * 5) + 150, Text = "Approx:" + volume };
                this.Controls.Add(templbl);
                _tmpLabels.Add(templbl);
            }
        }

        public static List<Tuple<Double, Double>> GetAveragePoints(List <Tuple<Double,Double>> toAvgFrom)
        {
            double runningaverage = 0.0;
            List<Tuple<double, double>> ptsAveraged = new List<Tuple<double, double>>();
            //take the average of all points
            for (int i = 0; i < toAvgFrom.Count; i++)
            {
                runningaverage += toAvgFrom[i].Item2;
            }
            runningaverage = runningaverage / toAvgFrom.Count;

            // for each point, search in the area around it to find a local average
            for (int i = 0; i < toAvgFrom.Count; i++)
            {
                double yavg = 0.0;
                double pointsAdded = 0.0;
                for (int j = Math.Max(i - AVERAGE_REACH, 0); j < Math.Min(i + AVERAGE_REACH, toAvgFrom.Count()); j++)
                {                    
                    double val = toAvgFrom[j].Item2;
                    //if the value is very far from the overall average,
                    // severely reduce its impact on the local average
                    if (Math.Abs(val - runningaverage) > 40)
                    {
                        yavg += toAvgFrom[j].Item2 / 5;
                        pointsAdded += 0.2;
                    }
                    //if the value is somehwat far from the overall average,
                    //reduce its impact on the local average
                    else if (Math.Abs(val - runningaverage) > 15)
                    {
                        yavg += toAvgFrom[j].Item2 / 2;
                        pointsAdded += 0.5;
                    }
                    else
                    {
                        yavg += toAvgFrom[j].Item2;
                        pointsAdded++;
                    }
                }
                yavg = yavg / pointsAdded;
                ptsAveraged.Add(new Tuple<double, double>(toAvgFrom[i].Item1, yavg));
            }
            return ptsAveraged;
        }
        public static List<Tuple<Double, Double>> RemoveOutliers(List<Tuple<Double, Double>> toRemoveFrom, List<Tuple<Double, Double>> expectedAverage, int tolerance)
        {
            _tempOutliers = 0;
            List<Tuple<Double, Double>> noOutliers = new List<Tuple<double, double>>();
            if (toRemoveFrom.Count != expectedAverage.Count)
            {
                throw new ArgumentException("point counts must be equal");
            }
            for (int i = 0; i < toRemoveFrom.Count; i++)
            {
                //if the point is sufficiently close to the expected average
                if (Math.Abs(_pts[i].Item2 - expectedAverage[i].Item2) < tolerance)
                {
                    //add it to the output
                    noOutliers.Add(_pts[i]);
                }
                else
                {
                    //if it is too far away, instead add the expected average
                    noOutliers.Add(expectedAverage[i]);
                    _tempOutliers++;
                }
            }
            return noOutliers;
        }

        public static List<Tuple<Double, Double>> Combine(List<Tuple<Double, Double>> pts1, List<Tuple<Double, Double>> pts2)
        {
            List<Tuple<Double, Double>> combination = new List<Tuple<double, double>>();
            for(int i = 0; i < pts1.Count; i++)
            {
                combination.Add(new Tuple<Double, Double>(pts1[i].Item1, (pts1[i].Item2 + pts2[i].Item2) / 2));
            }
            return combination;
        }

        public static List<Tuple<Double, Double>> findBestFitHorizontal(List<Tuple<Double, Double>> ptsToFlatten)
        {
            List<Tuple<Double, Double>> horizontalFit = new List<Tuple<double, double>>();
            Dictionary<int, int> rows = new Dictionary<int, int>();
            foreach (Tuple<Double, Double> avgpt in ptsToFlatten)
            {
                int rowLow = (int)Math.Floor(avgpt.Item2);
                int rowHigh = (int)Math.Ceiling(avgpt.Item2);
                int rowClose = (int)avgpt.Item2;
                addrow(rowLow, rows);
                addrow(rowLow - 1, rows);
                addrow(rowHigh, rows);
                addrow(rowHigh + 1, rows);
                addrow(rowClose, rows);
            }
            int mostRow = rows.Keys.First();
            foreach(int rownum in rows.Keys)
            {
                if(rows[mostRow] < rows[rownum])
                {
                    mostRow = rownum;
                }
            }
            _bestRow = mostRow;
            foreach(Tuple<Double, Double> pt in ptsToFlatten)
            {
                horizontalFit.Add(new Tuple<double, double>(pt.Item1, _bestRow));
            }
            return horizontalFit;
        }

        public static void addrow(int row, Dictionary<int, int> rows)
        {
            if (rows.ContainsKey(row))
            {
                rows[row] = rows[row] + 1;
            }
            else
            {
                rows[row] = 1;
            }
        }

        public static void findIrregularities(Dictionary<int, int> bumps, List<Tuple<double, double>> massagedData, double flatline)
        {
            //positive if we are tracing the edge of a bump
            int tracingbump = 0;
            //just a marker
            int startpos = 0;

            for(int i = 0; i < massagedData.Count; i++)
            {
                //if we are above the flat surface of the board
                if(massagedData[i].Item2 - flatline > 3)
                {
                    //if we arent already tracing a bump
                    if (tracingbump < 0)
                    {
                        //set the start position of the bump to the point we just left
                        startpos = Math.Max(0, i - 2);
                        //this will create a new "bump entry" in the next step
                    }
                    //bumps is a KV pair denoting start and end positions of the bump
                    //mark or remark the start, and the current end
                    bumps[startpos] = i;
                    //we set tracingbump to a positive value, to signifiy that we are still
                    //inside the boundaries of the current bump
                    tracingbump = 3;
                }
                else
                {
                    if(tracingbump > 0)
                    {
                        bumps[startpos] = i;
                    }
                    //if we arent still tracing a bump and the previous bump was very small, remove it
                    if (tracingbump < 0 && bumps.ContainsKey(startpos) && bumps[startpos] - startpos < MIN_BUMP_SIZE)
                    {
                        bumps.Remove(startpos);
                    }
                    tracingbump -= 1;
                }
            }
            //remove the last bump if it is very small
            if (bumps.ContainsKey(startpos) && bumps[startpos] - startpos < MIN_BUMP_SIZE)
            {
                bumps.Remove(startpos);
            }
        }

        private void buttonNewData_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            List<int> bumps = new List<int>();
            for(int i = 0; i < r.Next(0, 4); i++)
            {
                bumps.Add(r.Next(-20, 120));
            }
            List<int> divits = new List<int>();
            for (int i = 0; i < r.Next(0, 4); i++)
            {
                divits.Add(r.Next(-20, 120));
            }

            double currentLevel = r.NextDouble() + r.Next(45, 75);
            double startLevel = currentLevel;

            double noise = r.NextDouble() + r.NextDouble();

            for(int i = 0; i < 101; i++)
            {
                String line = "";
                //write out an x value. Make these pretty consistent, and ascending
                line += (i + r.NextDouble() - 0.5).ToString();
                line += "\t";
                //move randomly, but tend towards the starting point to give a flat 'board angle'
                if(currentLevel < startLevel)
                {
                    currentLevel += r.NextDouble();
                    currentLevel += r.NextDouble();
                    currentLevel -= r.NextDouble();
                }
                else
                {
                    currentLevel += r.NextDouble();
                    currentLevel -= r.NextDouble();
                    currentLevel -= r.NextDouble();
                }
                foreach (int b in bumps)
                {
                    //if we are close to the bump
                    if (Math.Abs(i - b) < 20)
                    {
                        //and we are in front of the bump
                        if (i - b < 0)
                        {
                            //go up a little
                            currentLevel += r.NextDouble();
                            //if we arent too close to the the bump we can go up a little more 
                            if (Math.Abs(i - b) > 10)
                                currentLevel += r.NextDouble();
                            //if we are right at the edge of the bump we go up a lot
                            if (Math.Abs(i - b) > 5)
                                currentLevel += r.NextDouble();
                        }
                        else
                        {
                            //fall a little, since we are on the falling edge
                            currentLevel -= r.NextDouble();
                        }
                    }
                }
                foreach (int d in divits)
                {
                    //if we are close to the divit
                    if (Math.Abs(i - d) < 20)
                    {
                        //and we are in front of the divit
                        if (i - d < 0)
                        {
                            //go down a little
                            currentLevel -= r.NextDouble();
                            //if we arent too close to the the divit we can go down a little more 
                            if (Math.Abs(i - d) > 10)
                                currentLevel -= r.NextDouble();
                            //if we are right at the edge of the divit we go down a lot
                            if (Math.Abs(i - d) > 5)
                                currentLevel -= r.NextDouble();
                        }
                        else
                        {
                            //go up a little, since we are on the rising edge
                            currentLevel += r.NextDouble();
                        }
                    }
                }
                if (r.NextDouble() < noise)
                {
                    //if we are below the noise threshold, use the thing we just calculated (could be optimized)
                    line += currentLevel.ToString();
                }
                else
                {
                    //otherwise throw in random garbage
                    line += (100 * r.NextDouble()).ToString();
                }
                line += "\n";
                sb.Append(line);
            }
            File.WriteAllText("Datafiles\\Data" + (Directory.GetFiles("Datafiles").Count() + 1).ToString() + ".txt", sb.ToString());
            comboBoxFiles.DataSource = Directory.GetFiles("Datafiles");
            comboBoxFiles.Text = "Datafiles\\Data" + (Directory.GetFiles("Datafiles").Count()).ToString() + ".txt";
            buttonLookForLine_Click(null, null);
        }
    }
}
