using System;
using System.Windows.Forms;

namespace Pong.Source
{
    internal static class Program
    {
        /// <summary>
        /// The Main method of the Application, also named as the Entrypoint.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Pong.Instance.Initialize();
        }
    }
}
