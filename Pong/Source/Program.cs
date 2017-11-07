using System;
using System.Windows.Forms;

namespace Pong.Source
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt(Entrypoint) für die Anwendung.
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
