using RetroTable.Main;
using RetroTable.MySql;

namespace RetroTable.Pong
{
    public class PongRecords
    {
        internal int BallSwitches_Game_Id1;
        internal int BallSwitches_Game_Id2;
        internal int BallSwitches_Game;

        internal int BallSwitches_Round_Id1;
        internal int BallSwitches_Round_Id2;
        internal int BallSwitches_Round;

        internal int MostScores_Id;
        internal int MostScores;

        internal int MostScores_Game_Id1;
        internal int MostScores_Game_Id2;
        internal int MostScores_Game;

        internal void Save()
        {
            if (Retrotable.Databasemode)
                Database.Records.RecordsSave(this);
        }
    }
}
