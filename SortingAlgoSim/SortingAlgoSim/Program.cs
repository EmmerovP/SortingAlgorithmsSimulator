using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Sorting algorithms simulator
 * Credit program for winter semester of C# Language and .NET Framework, 2018
 * Author: Petra Emmerová
 * 
 * */
namespace SortingAlgoSim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SelectParamWin());
        }
    }
}
