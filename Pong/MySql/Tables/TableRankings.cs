using RetroTable.Bounce;
using System;
using System.Collections.Generic;

namespace RetroTable.MySql.Tables
{
    public interface TableRankings
    {
        List<BounceHighscore> RankingsLoad();
        void RankingSave();
        BounceHighscore RankingCreate(int userId, int score, int duration, int panelSize, float ballSpeed, DateTime created);
    }
}
