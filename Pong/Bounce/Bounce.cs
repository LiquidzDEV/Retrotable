using RetroTable.Main;
using RetroTable.MySql;
using RetroTable.UserSystem;
using System;
using System.Collections.Generic;

namespace RetroTable.Bounce
{
    public class Bounce
    {
        internal List<HistoryEntry> LastRanking = new List<HistoryEntry>();

        internal List<Ball> Balls { get; }

        internal Player Player { get; }

        private BounceForm BounceForm;

        internal int TimePassed;

        private bool Started;

        public Bounce()
        {
            if (Retrotable.Databasemode)
                LastRanking = Database.History.HistoryGetBounceRanking();

            Balls = new List<Ball>();
            BounceForm = new BounceForm(this);
            Player = new Player(BounceForm, 1);
        }

        internal void Show()
        {
            Player.Height = UserManager.Player1.PanelSize;
            BounceForm.Show();

            Retrotable.LiveGameData.running = 2;
            Retrotable.LiveGameData.user_Id1 = UserManager.Player1.User_Id;
            Retrotable.LiveGameData.score1 = 0;
            Retrotable.LiveGameData.timeleft = 0;
            Retrotable.UpdateLiveGameData();
        }

        internal void Hide()
        {
            Reset();
            BounceForm.Hide();

            Retrotable.LiveGameData.running = 0;
            Retrotable.UpdateLiveGameData();
        }

        internal void Start()
        {
            if (Started) return;

            Player.SetScore(0);          
            TimePassed = 0;

            
            Retrotable.LiveGameData.score1 = 0;
            Retrotable.LiveGameData.timeleft = 0;
            Retrotable.UpdateLiveGameData();

            Balls.Add(new Ball(BounceForm));
            BounceForm.timerMain.Start();
            BounceForm.timerBalls.Start();
            BounceForm.timerAddBall.Start();
            BounceForm.HideRanking();
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
            HistoryEntry history = HistoryEntry.Create(UserManager.Player1, Player.Score, TimePassed);               
            LastRanking.Add(history);
            TryUpdateRanking();
            BounceForm.ShowRanking(history);
        }

        private void TryUpdateRanking()
        {
            if (Retrotable.Databasemode)
                LastRanking = Database.History.HistoryGetBounceRanking();
        }
    }
}
