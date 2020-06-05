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

namespace MagicTestingWare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            String [] decks = Directory.GetFiles("Datafiles");
            comboBox1.DataSource = decks;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.Create("Datafiles\\" + textBox1.Text + ".txt");
            String[] decks = Directory.GetFiles("Datafiles");
            comboBox1.DataSource = decks;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String [] cards = File.ReadAllLines(comboBox1.Text);
            List<Card> cardobjs = new List<Card>();
            foreach(String str in cards)
            {
                if(str == "//SB")
                {
                    break;
                }
                cardobjs.Add(new Card() { Name = str });
            }
            DeckInterface fromopener = new DeckInterface(cardobjs);
            fromopener.Show();
        }
    }
}
