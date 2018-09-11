using RetroTable.Board;
using RetroTable.Main;
using RetroTable.UserSystem;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RetroTable.Pong.Components
{
    /// <summary> The Class for the ball on the playground. </summary>
    public class Ball
    {
        private Pong Main;

        /// <summary> Speed of the ball on round start. </summary>
        private const float DefaultSpeed = 5f;
        /// <summary> The speed that the ball gains per Event. </summary>
        private const float SpeedGain = 0.3f;
        /// <summary> The maximum horizontal speed of the ball. </summary>
        private const float MaxSpeed = 80f;

        /// <summary> The speed that is configured over the options. </summary>
        private static float _speedLevel = 2f;

        private readonly PictureBox _pBall;
        internal float Speed { get; private set; }
        internal float Angle { get; private set; }

        private int _lastPlayerHit;

        public Ball(Pong main, PictureBox pBall)
        {
            Main = main;
            _pBall = pBall;
        }

        /// <summary> Starts the movement of the ball. </summary>
        public void Start()
        {
            //Sets the y-speed of the ball randomly between -6 and 6
            Angle = 0; //TODO Retrotable.Random.Next(-6, 6);
            //Sets the x-speed on positive defaultspeed if random is lower than 5 and negative defaultspeed if random is greater or equal than 5
            Speed = Retrotable.Random.Next(10) < 5 ? DefaultSpeed : -DefaultSpeed;
        }

        /// <summary> Detects and sets the new movement for the ball. </summary>
        public void Move()
        {
            int bottom = World.Bottom - _pBall.Size.Height;

            //Move the ball left and right, if he hits up/down border don´t move him vertical
            _pBall.Location = new Point(_pBall.Location.X + (int)Speed, Math.Max(World.Upper, Math.Min(bottom, _pBall.Location.Y + (int)Angle)));

            //If the ball hits up/down border change his vertical direction
            if (_pBall.Location.Y == bottom || _pBall.Location.Y == World.Upper)
            {
                Angle *= -1;
                System.Diagnostics.Debug.WriteLine("Ball changes direction!");
            }

            //If the ball hits a player change his horizontal direction and calculate a new angle
            Reverse(IsBallHittingPlayer());


            //If the ball goes behind a player, give the other player a point
            if (_pBall.Location.X >= World.Right - _pBall.Size.Width - 36)
            {
                if (Main.Player2.GetRelativeHitPosition(Main.Ball) != -1)
                {
                    //Ball ist durch den Spieler durch geflogen
                    Reverse(2);
                    return;
                }

                ArduinoHelper.StartBlinking(true);
                Main.Player1.Score();
                Retrotable.LiveGameData.score1++;
            }
            else if (_pBall.Location.X <= 36)
            {
                if (Main.Player1.GetRelativeHitPosition(Main.Ball) != -1)
                {
                    //Ball ist durch den Spieler durch geflogen
                    Reverse(1);
                    return;
                }

                ArduinoHelper.StartBlinking(false);
                Main.Player2.Score();
                Retrotable.LiveGameData.score2++;
            }
        }

        private void Reverse(int player)
        {
            if (player == 0) return;
            if (_lastPlayerHit == player) return;

            //save the last player that was hit, to pevent this code from executing twice
            _lastPlayerHit = player;

            //reverse the velocity from the ball
            Speed *= -1;

            //Calculating new angle

            var relativeHitPosition = player == 1 ? Main.Player1.GetRelativeHitPosition(Main.Ball) : Main.Player2.GetRelativeHitPosition(Main.Ball);
            Angle = (float)Math.Ceiling(24 * relativeHitPosition - 12);

#if !DEBUG
            if (Angle == 0f)
                Angle = new Random().Next(100) < 50 ? -1 : 1;
#endif

            //old calculation (Small Project)
            //int random = new Random().Next(1, 12);
            //Angle = Angle < 0 ? -random : random;

            //incrementing statistics
            if (player == 1)
                UserManager.Player1.DefendTimesPong++;
            else
                UserManager.Player2.DefendTimesPong++;

            Main.BallSwitchesRound++;
            Main.BallSwitchesGame++;

            //Debug Message
            System.Diagnostics.Debug.WriteLine("Spieler " + player + " wurde vom Ball getroffen! Neuer Flugwinkel: " + Angle);
        }

        /// <summary>
        /// If the ball is hitting some player, this method returns the player id, otherwise 0.
        /// </summary>
        /// <returns>The playerid, otherwise 0</returns>
        private int IsBallHittingPlayer()
        {
            if (Main.Player1.Hits(_pBall))
                return 1;
            if (Main.Player2.Hits(_pBall))
                return 2;
            return 0;
        }

        /// <summary> Increases the horizontal speed of the ball to the given movement.
        /// If the Speed is already MaxSpeed do nothing, if the Speed is greater than MaxSpeed set it to MaxSpeed</summary>
        public void IncreaseSpeed()
        {
            if (Math.Abs(Speed) == MaxSpeed) return;

            if (Math.Abs(Speed) > MaxSpeed)
            {
                Speed = Speed < 0f ? -MaxSpeed : MaxSpeed;
                return;
            }

            Speed = Speed < 0f ? Speed - SpeedGain * _speedLevel : Speed + SpeedGain * _speedLevel;
            System.Diagnostics.Debug.WriteLine("BallSpeed erhöht auf " + Speed);
        }

        /// <summary> Sets the Speedlevel of the ball. </summary>
        public static void SetSpeedLevel(float level)
        {
            _speedLevel = level;
            System.Diagnostics.Debug.WriteLine("Ballspeedlevel was set to " + level + "!");
        }

        internal Rectangle GetBounds()
        {
            return _pBall.Bounds;
        }

        /// <summary> Resets the position of the ball. </summary>
        public void Reset()
        {
            _pBall.Location = new Point(((World.Right - World.Left) / 2) - (_pBall.Size.Width / 2), ((World.Bottom - World.Upper) / 2) - (_pBall.Size.Height / 2));
            _lastPlayerHit = 0;
        }
    }
}
