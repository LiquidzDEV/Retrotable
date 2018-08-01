using RetroTable.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.Bounce
{
    public class Bounce
    {
        internal List<Ball> Balls { get; }

        internal Player Player { get; }

        private BounceForm BounceForm;

        internal int TimePassed;

        private bool Started;

        public Bounce()
        {
            Balls = new List<Ball>();
            BounceForm = new BounceForm(this);
            Player = new Player(BounceForm, 1);
        }

        internal void Show()
        {
            Player.Height = UserManager.Player1.PanelSize;
            BounceForm.Show();
        }

        internal void Hide()
        {
            Reset();
            BounceForm.Hide();
        }

        internal void Start()
        {
            if (Started) return;

            Player.SetScore(0);
            TimePassed = 0;
            Balls.Add(new Ball(BounceForm));
            BounceForm.timerMain.Start();
            BounceForm.timerBalls.Start();
            BounceForm.timerAddBall.Start();

            Started = true;
        }

        internal void Reset()
        {
            foreach (var ball in Balls)
            {
                ball.Dispose();
            }
            Balls.Clear();
            BounceForm.timerMain.Stop();
            BounceForm.timerBalls.Stop();
            BounceForm.timerAddBall.Stop();
            Started = false;
        }

        internal void Finish()
        {
            Reset();
            //Database
        }
    }
}
