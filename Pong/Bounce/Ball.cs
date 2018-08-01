using RetroTable.Main;
using RetroTable.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroTable.Bounce
{
    /// <summary> Ball for the Retrotable Version 2 </summary>
    internal partial class Ball : PictureBox
    {
        private const int DefaultSpeed = 5;
        private const float SpeedGain = 0.3f;

        private Bounce Main;

        internal int Id { get; private set; }
        internal float Speed { get; private set; }
        internal float Angle { get; private set; }

        private int LastTouched = -1;

        public Ball(Form parent)
        {
            Main = Retrotable.Instance.Bounce;

            Id = Retrotable.Random.Next(1048576);

            Anchor = AnchorStyles.None;
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImage = ballBlack;
            BackgroundImageLayout = ImageLayout.Center;
            Margin = new Padding(4);
            Name = "pBall" + Id;
            Size = new System.Drawing.Size(20, 20);
            TabStop = false;

            parent.Controls.Add(this);

            Location = new System.Drawing.Point(Retrotable.Random.Next(30, Parent.Width - 100 - Width / 2), Retrotable.Random.Next(0, Parent.Height - Height / 2));
            Start();
        }

        private void Start()
        {
            Angle = Retrotable.Random.Next(-6, 7);
            Speed = DefaultSpeed;
        }

        internal new void Move()
        {
            Location = new System.Drawing.Point(Location.X + (int)Speed, Math.Min(Parent.Height - Height, Math.Max(0, Location.Y + (int)Angle)));

            if (Location.Y == 0 || Location.Y == Parent.Height - Height)
                Angle *= -1;

            if (LastTouched != 0 && Bounds.Right > Parent.Width - 150)
            {
                Speed *= -1;
                LastTouched = 0;
                Main.Player.SetScore(Main.Player.Score + 1);
            }

            if (LastTouched != 1 && Location.X <= Main.Player.Bounds.Right)
            {
                if (Bounds.Bottom > Main.Player.Bounds.Top && Bounds.Top < Main.Player.Bounds.Bottom)
                {
                    Location = new System.Drawing.Point(Main.Player.Bounds.Right, Location.Y);
                    Speed *= -1;
                    LastTouched = 1;

                    float relativeHitPosition = ((Location.Y + Bounds.Height / 2f) - Main.Player.Location.Y) / Main.Player.Height;
                    Angle = (int)Math.Ceiling(24f * relativeHitPosition - 12f);

                    if (Angle == 0)
                        Angle = new Random().Next(100) < 50 ? -1 : 1;
                }
                else
                {
                    Main.Balls.Remove(this);
                    if (Main.Balls.Count == 0)
                        Main.Finish();
                    Dispose();
                }
            }
        }

        internal void IncreaseSpeed()
        {
            Speed = Speed < 0 ? Speed - SpeedGain * UserManager.Player1.BallSpeed : Speed + SpeedGain * UserManager.Player1.BallSpeed;
        }
    }
}
