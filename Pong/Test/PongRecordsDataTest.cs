using RetroTable.Main;
using RetroTable.UserSystem;
using System;
using System.Windows.Forms;

namespace RetroTable.Test
{
    public partial class PongRecordsDataTest : Form
    {
        public PongRecordsDataTest()
        {
            InitializeComponent();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            var records = Retrotable.Instance.Pong.Records;

            lblBallSwitchesGameId1.Text = UserManager.GetName(records.BallSwitches_Game_Id1) + "(" + records.BallSwitches_Game_Id1 + ")";
            lblBallSwitchesGameId2.Text = UserManager.GetName(records.BallSwitches_Game_Id2) + "(" + records.BallSwitches_Game_Id2 + ")";
            lblBallSwitchesGame.Text = records.BallSwitches_Game.ToString();

            lblBallSwitchesRoundId1.Text = UserManager.GetName(records.BallSwitches_Round_Id1) + "(" + records.BallSwitches_Round_Id1 + ")";
            lblBallSwitchesRoundId2.Text = UserManager.GetName(records.BallSwitches_Round_Id2) + "(" + records.BallSwitches_Round_Id2 + ")";
            lblBallSwitchesRound.Text = records.BallSwitches_Round.ToString();

            lblMostScoresId.Text = UserManager.GetName(records.MostScores_Id) + "(" + records.MostScores_Id + ")";
            lblMostScores.Text = records.MostScores.ToString();

            lblMostScoresInGameId1.Text = UserManager.GetName(records.MostScores_Game_Id1) + "(" + records.MostScores_Game_Id1 + ")";
            lblMostScoresInGameId2.Text = UserManager.GetName(records.MostScores_Game_Id2) + "(" + records.MostScores_Game_Id2 + ")";
            lblMostScoresInGame.Text = records.MostScores_Game.ToString();
        }
    }
}
