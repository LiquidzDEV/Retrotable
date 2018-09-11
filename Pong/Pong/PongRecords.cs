using RetroTable.Main;
using RetroTable.MySql;

namespace RetroTable.Pong
{
    public class PongRecords
    {
        internal int BallSwitchesGameId1;
        internal int BallSwitchesGameId2;
        internal int BallSwitchesGame;

        internal int BallSwitchesRoundId1;
        internal int BallSwitchesRoundId2;
        internal int BallSwitchesRound;

        internal int MostScoresId;
        internal int MostScores;

        internal int MostScoresInGameId1;
        internal int MostScoresInGameId2;
        internal int MostScoresInGame;

        internal void Save()
        {
            if (Retrotable.Databasemode)
                Database.Records.RecordsSave(this);
        }
    }
}
