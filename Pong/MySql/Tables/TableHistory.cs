using RetroTable.Main;
using System;
using System.Collections.Generic;

namespace RetroTable.MySql.Tables
{
    public interface TableHistory
    {
        List<HistoryEntry> HistoryGetBounceRanking();
        HistoryEntry HistoryAddEntry(int game, int user_Id, int score, int panel_size, float ball_speed, int? user_Id2, int score2, int panel_size2, float ball_speed2, int time, DateTime created);
    }
}
