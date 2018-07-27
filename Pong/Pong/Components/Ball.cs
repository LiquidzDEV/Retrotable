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
        private const float DefaultSpeed = 10f;
        /// <summary> The speed that the ball gains per Event. </summary>
        private const float SpeedGain = 0.3f;
        /// <summary> The maximum horizontal speed of the ball. </summary>
        private const float MaxSpeed = 35f;

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
            //Creates an instance of a generator for random numbers
            var random = new Random();
            //Sets the y-speed of the ball randomly between -4 and 4
            Angle = random.Next(-4, 4);
            //Sets the x-speed on positive defaultspeed if random is lower than 5 and negative defaultspeed if random is greater or equal than 5
            Speed = random.Next(10) < 5 ? DefaultSpeed : -DefaultSpeed;
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
            int playerHit = IsBallHittingPlayer();
            if (playerHit > 0 && _lastPlayerHit != playerHit)
            {
                _lastPlayerHit = playerHit;
                Speed *= -1;

                //Calculating new angle

                var relativeHitPosition = playerHit == 1 ? Main.Player1.GetRelativeHitPosition(Main.Ball) : Main.Player2.GetRelativeHitPosition(Main.Ball);

                Angle = 24 * relativeHitPosition - 12;

                //int random = new Random().Next(1, 12);
                //_speedY = _speedY < 0 ? -random : random;

                if (playerHit == 1)
                    UserManager.Player1.DefendTimesPong++;
                else
                    UserManager.Player2.DefendTimesPong++;

                Main.BallSwitchesRound++;
                Main.BallSwitchesGame++;

                System.Diagnostics.Debug.WriteLine("Spieler " + playerHit + " wurde vom Ball getroffen! Neuer Flugwinkel: " + Angle);
            }

            //If the ball goes behind a player, give the other player a point
            if (_pBall.Location.X >= World.Right - _pBall.Size.Width)
            {
                ArduinoHelper.StartBlinking(true);
                Main.Player1.Score();
            }
            else if (_pBall.Location.X <= 0)
            {
                ArduinoHelper.StartBlinking(false);
                Main.Player2.Score();
            }
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

        /// <summary> Increases the horizontal speed of the ball to the given movement. </summary>
        public void IncreaseSpeed()
        {
            if (Speed < MaxSpeed * _speedLevel && Speed > -MaxSpeed * _speedLevel)
            {
                Speed = Speed < 0f ? Speed - SpeedGain * _speedLevel : Speed + SpeedGain * _speedLevel;
                System.Diagnostics.Debug.WriteLine("BallSpeed erhöht auf " + Speed);
            }
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
