using RetroTable.Board;
using RetroTable.Main;
using RetroTable.Pong.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.Pong
{
    public class Pong
    {
        private PongForm Pongform;

        /// <summary> Holding the instance of a Player. </summary>
        internal Player Player1, Player2;

        /// <summary> Holding the instance of the <see cref="Ball"/>. </summary>
        internal Ball Ball;

        /// <summary> True, if a match is running. </summary>
        internal bool Started { get; private set; }

        public Pong()
        {
            Pongform = new PongForm(this);
        }

        internal void Show()
        {
            Reset();
            Pongform.Show();
        }

        internal void Hide()
        {
            Pongform.Hide();
        }

        internal void Start()
        {
            if (Started) return;

            Ball.Start();
            Started = true;

            if (Retrotable.ArduinoMode)
            {
                ArduinoHelper.SetStartLeds(false, false);
                ArduinoHelper.StopBlinking();
            }
        }

        internal void Reset()
        {
            Started = false;
            Pongform.ResetRound();
            Player1.Reset();
            Player2.Reset();
            Ball.Reset();
            System.Diagnostics.Debug.WriteLine("Spiel wurde zurückgesetzt.");
        }
    }
}
