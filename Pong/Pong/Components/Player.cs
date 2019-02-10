using RetroTable.Board;
using RetroTable.Main;
using RetroTable.UserSystem;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RetroTable.Pong.Components
{
    /// <summary> This Class holds the variables for one player. </summary>
    public class Player
    {
        /// <summary> The movement speed of the player. </summary>
		private const int Speed = 20;

        private readonly Panel _pnl;
        private readonly Label _lblScore;

        private readonly bool Player1;

        public bool PlayerUp;
        public bool PlayerDown;

        internal int ScorePoints { get; set; }

        public Player(bool player1, Panel pnl, Label lblScore)
        {
            Player1 = player1;
            _pnl = pnl;
            _lblScore = lblScore;

            Retrotable.onValueChanged += RetroTable_onValueChanged;
        }

        private void RetroTable_onValueChanged(PinMapping pin, int newValue)
        {
            if (!_pnl.Parent.Visible) return;
            if (Player1 && pin != PinMapping.Player1SliderTotal) return;
            if (!Player1 && pin != PinMapping.Player2SliderTotal) return;

            if (pin == PinMapping.Player1SliderTotal)
                newValue = 100 - newValue;

            double position = (World.Bottom - _pnl.Size.Height - World.Upper) / 100f * newValue;
            _pnl.Invoke((MethodInvoker)delegate
            {
                _pnl.Location = new Point(_pnl.Location.X, Math.Min(World.Bottom - _pnl.Size.Height, Convert.ToInt32(position) + World.Upper));
            });
        }

        /// <summary> Let the player move, depending which button is pressed, when no Arduino is connected. </summary>
        public void Move()
        {
            if (PlayerUp)
            {
                _pnl.Location = new Point(_pnl.Location.X, Math.Max(World.Upper, _pnl.Location.Y - Speed));
            }
            else if (PlayerDown)
            {
                _pnl.Location = new Point(_pnl.Location.X, Math.Min(World.Bottom - _pnl.Size.Height, _pnl.Location.Y + Speed));
            }
        }

        /// <summary> Gives this player a scorepoint. </summary>
        internal void Score()
        {
            ScorePoints++;
            _lblScore.Text = ScorePoints + "\n" + (Player1 ? UserManager.Player1.Name : UserManager.Player2.Name);

            if (Player1)
            {
                UserManager.Player1.MadeGoals_Pong++;
                UserManager.Player2.TakenGoals_Pong++;               
            }
            else
            {
                UserManager.Player2.MadeGoals_Pong++;
                UserManager.Player1.TakenGoals_Pong++;
            }

            var pong = Retrotable.Instance.Pong;
            if (pong.BallSwitchesRound > pong.Records.BallSwitches_Round)
            {
                pong.Records.BallSwitches_Round = pong.BallSwitchesRound;
                pong.Records.BallSwitches_Round_Id1 = UserManager.Player1.User_Id;
                pong.Records.BallSwitches_Round_Id2 = UserManager.Player2.User_Id;
                pong.Records.Save();
            }

            pong.ResetRound();
            System.Diagnostics.Debug.WriteLine("Ein Punkt wurde vergeben.");
        }

        /// <summary> Sets the players panel position relative to the poti value. </summary>
        [Obsolete("Replaced with Eventhandler onValueChanged", true)]
        internal void SetRelativePanelPosition(int percentage)
        {
            if (Player1)
                percentage = 100 - percentage;

            double position = (World.Bottom - _pnl.Size.Height - World.Upper) / 100f * percentage;
            _pnl.Location = new Point(_pnl.Location.X, Math.Min(World.Bottom - _pnl.Size.Height, Convert.ToInt32(position) + World.Upper));
        }

        /// <summary> Changes the panel height. </summary>
        public void SetPanelHeight(int height)
        {
            _pnl.Height = height;
            System.Diagnostics.Debug.WriteLine("Höhe des Balken wurde auf " + height + " gesetzt!");
        }

        internal bool Hits(PictureBox ball)
        {
            return _pnl.Bounds.IntersectsWith(ball.Bounds);
        }

        /// <summary> Gibt die relative Position zurück, in welcher Höher der Ball den Balken gerade berührt.</summary>
        /// <returns>Die Position in relativer Angabe (0-1) wo der Ball den Balken getroffen hat. -1 wenn der Ball den Balken nicht berührt.</returns>
        public float GetRelativeHitPosition(Ball ball)
        {
            var bounds = ball.GetBounds();
            bounds.X = !Player1 ? _pnl.Bounds.Right - 1 : _pnl.Bounds.Left + 1;
            if (_pnl.Bounds.IntersectsWith(bounds))
            {
                var hitPosition = (bounds.Y + bounds.Height / 2f) - _pnl.Bounds.Y;
                var relativeHitPosition = hitPosition / _pnl.Bounds.Height;
                System.Diagnostics.Debug.WriteLine("HitPosition: " + hitPosition + "px | Relative: " + relativeHitPosition);
                return relativeHitPosition;
            }
            return -1;
        }

        internal void Reset()
        {
            _pnl.Location = new Point(_pnl.Location.X, ((World.Bottom - World.Upper) / 2) - (_pnl.Size.Height / 2));
            _lblScore.Text = ScorePoints + "\n" + (Player1 ? UserManager.Player1.Name : UserManager.Player2.Name);
        }

        public void Resize()
        {
            int x = !Player1 ? 10 : World.Right - _pnl.Size.Width - 10;
            _pnl.Location = new Point(x, Math.Min(World.Bottom - _pnl.Size.Height, _pnl.Location.Y));
        }
    }
}
