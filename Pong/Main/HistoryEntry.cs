using RetroTable.MySql;
using RetroTable.UserSystem;
using System;

namespace RetroTable.Main
{
    internal class HistoryEntry
    {
        internal int History_Id { get; private set; }
        internal int Game { get; private set; }
        internal int User_Id { get; private set; }
        internal int Panel_Size { get; private set; }
        internal float Ball_Speed { get; private set; }
        internal int? User_Id2 { get; private set; }
        internal float Ball_Speed2 { get; private set; }
        internal int Panel_Size2 { get; private set; }
        internal int Score { get; private set; }
        internal int Score2 { get; private set; }
        internal int Time { get; private set; }
        internal DateTime Created { get; private set; }

        private static HistoryEntry Create(int game, int user_Id, int score, int panel_size, float ball_speed, int? user_Id2, int score2, int panel_size2, float ball_speed2, int time)
        {
            if (Retrotable.Databasemode)
                return Database.History.HistoryAddEntry(game, user_Id, score, panel_size, ball_speed, user_Id2, score2, panel_size2, ball_speed2, time, DateTime.Now);
            else
                return new HistoryEntry
                {
                    Game = game,
                    User_Id = user_Id,
                    Score = score,
                    Panel_Size = panel_size,
                    Ball_Speed = ball_speed,
                    User_Id2 = user_Id2,
                    Score2 = score2,
                    Panel_Size2 = panel_size2,
                    Ball_Speed2 = ball_speed2,
                    Time = time,
                    Created = DateTime.Now
                };
        }

        internal static HistoryEntry Create(User user, int score, User user2, int score2, int time)
        {
            return Create(1, user.User_Id, score, user.PanelSize, user.BallSpeed, user2?.User_Id, score2, user2 == null ? 0 : user2.PanelSize, user2 == null ? 0f : user2.BallSpeed, time);
        }

        internal static HistoryEntry Create(User user, int score, int time)
        {
            return Create(2, user.User_Id, score, user.PanelSize, user.BallSpeed, null, 0, 0, 0f, time);
        }
    }

}
