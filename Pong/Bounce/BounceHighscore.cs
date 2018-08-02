using RetroTable.Main;
using RetroTable.MySql;
using RetroTable.UserSystem;
using System;

namespace RetroTable.Bounce
{
    public class BounceHighscore
    {
        public int Id;
        public int UserId;
        public int Score;
        public int Duration;
        public int PanelSize;
        public float BallSpeed;
        public DateTime Created;

        internal static BounceHighscore Create(User player, int score, int duration)
        {
            var ranking = Database.Rankings.RankingCreate(player.Id, score, duration, player.PanelSize, player.BallSpeed, DateTime.Now);
            Retrotable.Instance.Bounce.Ranking.Add(ranking);
            return ranking;
        }
    }
}
