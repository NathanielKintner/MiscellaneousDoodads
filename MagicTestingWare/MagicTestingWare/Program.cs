using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MagicTestingWare
{
    public static class Program
    {
        public static Random r = new Random();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!Directory.Exists("Datafiles"))
                Directory.CreateDirectory("Datafiles");
            if (!Directory.Exists("Cardimages"))
                Directory.CreateDirectory("Cardimages");
            Application.Run(new Form1());
        }
    }
}
