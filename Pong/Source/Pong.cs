/*
 * Pascal "Liquidz" H.
 * Jannik H.
 * 10.02.2017 / 06:24
 */

using System;
using System.Windows.Forms;
using LattePanda.Firmata;
using Pong.Source.Components;

namespace Pong.Source
{
    /// <summary>
    /// Hauptklasse der Anwendung.
    /// Entrypoint befindet sich in Program.cs
    /// </summary>
    public class Pong
    {
        /// <summary> Erstellt eine Singleton-Instanz der Pong-Klasse </summary>
	    internal static Pong Instance { get; } = new Pong();

        /// <summary> false, wenn kein Arduino angeschlossen ist. </summary>
        internal static bool ARDUINOMODE = true;

        /// <summary> Hält die Instanz des SerialPorts für das Arduino. </summary>
        internal static Arduino Arduino { get; private set; }

        /// <summary> Unsere Form für das Spielfeld. </summary>
        internal MainForm mainForm { get; private set; }

        /// <summary> Hält Werte für die beiden Spieler. </summary>
        internal Player player1, player2;

        /// <summary> Hält Werte über den Ball. </summary>
        internal Ball ball;

        /// <summary> true, wenn ein Spiel zurzeit läuft. </summary>
        internal bool started;

        /// <summary> Initialisierung der Singleton Klasse. </summary>
        private bool initialized;
        internal void initialize()
        {
            if (initialized)
                return;

            mainForm = new MainForm();

            try
            {
                Arduino = new Arduino("COM3");

                ArduinoHelper.Setup();
            }
            catch (Exception)
            {
                Pong.ARDUINOMODE = false;
                MessageBox.Show("Es kann über W,S und Up,Down gespielt werden.\nMit Leertaste startet die Runde.", "Kein Arduino gefunden!");
            }

            Application.Run(mainForm);

            initialized = true;
        }

        /// <summary> true, um Debugmessages in die Konsole geschrieben zu bekommen. </summary>
        public static bool DEBUG = true;
        public static void debugMessage(string message)
        {
            if (DEBUG)
                System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
