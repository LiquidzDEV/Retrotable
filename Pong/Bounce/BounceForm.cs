using RetroTable.Main;
using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using RetroTable.UserSystem;

namespace RetroTable.Bounce
{
    public partial class BounceForm : Form
    {
        private Bounce Main;

        public BounceForm(Bounce main)
        {
            Main = main;
            InitializeComponent();
        }

        public new void Hide()
        {
            base.Hide();
            timerPaddle.Stop();
        }

        public new void Show()
        {
            Main.Player.Location = new Point(16, Height / 2 - Main.Player.Bounds.Height / 2);
            lblTime.NewText = "0 Minuten 0 Sekunden";
            lblScore.NewText = UserManager.Player1.Name + ": 0";
            timerPaddle.Start();
            base.Show();
        }

        private void BounceForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Main.Player.SetMoveSet(true, false);
                    break;
                case Keys.S:
                    Main.Player.SetMoveSet(false, false);
                    break;
                case Keys.Escape:
                    Main.Hide();
                    break;
                case Keys.Space:
                    Main.Start();
                    break;
            }
        }

        private void BounceForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Main.Player.SetMoveSet(true, true);
                    break;
                case Keys.S:
                    Main.Player.SetMoveSet(false, true);
                    break;
            }
        }

        internal void ShowRanking(BounceHighscore personalRanking = null)
        {
            var rankings = Main.Ranking.OrderByDescending(x => x.Score).ToList();

            lblRanking.Text = "";

            for (int i = 0; i < rankings.Count; i++)
            {
                var ranking = rankings[i];
                if (i == 0)
                {
                    lblFirst.Text = "1. " + ranking.UserId + ": " + ranking.Score;
                }
                else if (i == 1)
                {
                    lblSecond.Text = "2. " + ranking.UserId + ": " + ranking.Score;
                }
                else if (i == 2)
                {
                    lblThird.Text = "3. " + ranking.UserId + ": " + ranking.Score;
                }
                else if(i < 5)
                {
                    lblRanking.Text += (i + 1) + ". " + ranking.UserId + ": " + ranking.Score + "\n";
                }

                if(personalRanking != null && ranking == personalRanking)
                {
                    lblOwnRecord.Text = (i + 1) + ". " + ranking.UserId + ": " + ranking.Score;
                }
            }

            pnlRanking.Visible = true;
        }

        internal void HideRanking()
        {
            pnlRanking.Visible = false;
        }

        private void timerPaddle_Tick(object sender, EventArgs e)
        {
            Main.Player.Move();
        }


        private void timerMain_Tick(object sender, EventArgs e)
        {
            Main.TimePassed++;
            Retrotable.LiveGameData.timeleft++;
            Retrotable.UpdateLiveGameData();
            var time = new TimeSpan(0, 0, Main.TimePassed);
            lblTime.NewText = (int)time.TotalMinutes + " Minuten " + time.Seconds + " Sekunden";

            foreach (var ball in Main.Balls)
            {
                ball.IncreaseSpeed();
            }
        }

#if DEBUG
        private DateTime TickTime = DateTime.Now;
#endif
        private void timerBalls_Tick(object sender, EventArgs e)
        {
            for (int i = Main.Balls.Count - 1; i >= 0; i--)
            {
                Main.Balls[i].Move();
            }

#if DEBUG
            var newTime = DateTime.Now;
            lblDebug.Text = "Tick: " + (newTime - TickTime).TotalMilliseconds + "\n";
            foreach (var ball in Main.Balls)
            {
                lblDebug.Text += "Ball : " + ball.Id.ToString("X") + " Angle: " + ball.Angle + " Speed: " + ball.Speed + "\n";
            }
            TickTime = newTime;
#endif
        }

        private void timerAddBall_Tick(object sender, EventArgs e)
        {
            Main.Balls.Add(new Ball(this));
            timerAddBall.Interval = Retrotable.Random.Next(10000, 40000);
            timerAddBall.Start();
        }
    }
}
