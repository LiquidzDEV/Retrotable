/*
 * Pascal "Liquidz" H.
 * Jannik Herrmann, Jannic Walder, Marc Weißelstein
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
    internal class Pong
    {
        /// <summary> Erstellt eine Singleton-Instanz der Pong-Klasse </summary>
	    internal static Pong Instance { get; } = new Pong();

        /// <summary> false, wenn kein Arduino angeschlossen ist. </summary>
        internal static bool ArduinoMode = true;

        /// <summary> Hält die Instanz des Arduino. </summary>
        internal static Arduino Arduino { get; private set; }

        /// <summary> Unsere Form für das Spielfeld. </summary>
        internal MainForm MainForm { get; private set; }

        /// <summary> Hält Instanzen für die beiden Spieler. </summary>
        internal Player Player1, Player2;

        /// <summary> Hält die Instanz des Balls. </summary>
        internal Ball Ball;

        /// <summary> true, wenn ein Spiel zurzeit läuft. </summary>
        internal bool Started;

        /// <summary> Initialisierung der Singleton Klasse. </summary>
        private bool _initialized;
        internal void Initialize()
        {
            if (_initialized)
                return;

            try
            {
                Arduino = new Arduino("COM5");

                ArduinoHelper.Setup();
            }
            catch (Exception)
            {
                ArduinoMode = false;
                MessageBox.Show("Es kann über W,S und Up,Down gespielt werden.\nMit Leertaste startet die Runde.", "Kein Arduino gefunden!");
            }

            MainForm = new MainForm();

            if (ArduinoMode)
                Arduino.analogPinUpdated += Arduino_analogPinUpdated;

            Application.Run(MainForm);

            _initialized = true;
        }

        private void Arduino_analogPinUpdated(PinMapping pin, int value)
        {
            if (pin == PinMapping.Player1Bar)
                Player1.setRelativePanelPosition(value.Map(0, 1023, 0, 100));
            else if (pin == PinMapping.Player2Bar)
                Player2.setRelativePanelPosition(value.Map(0, 1023, 0, 100));
        }

        /// <summary> true, um Debugmessages in die Konsole geschrieben zu bekommen. </summary>
        private const bool Debug = true;
        internal static void DebugMessage(string message)
        {
            if (Debug) System.Diagnostics.Debug.WriteLine(message);
        }
    }
}
