using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lex4allGUI
{
    static class Program
    {
        public static MainForm main;
        public static StartForm start;
        public static EvalForm eval;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //main = new MainForm();
            //Application.Run(main);
            start = new StartForm();
            Application.Run(start);
        }
    }
}
