using System;
using System.Windows.Forms;

namespace Pong.Source
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt(Entrypoint) für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
			Pong.Instance.initialize();
        }
    }
}
