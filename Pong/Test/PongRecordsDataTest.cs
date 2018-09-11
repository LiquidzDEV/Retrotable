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

            lblBallSwitchesGameId1.Text = UserManager.GetName(records.BallSwitchesGameId1) + "(" + records.BallSwitchesGameId1 + ")";
            lblBallSwitchesGameId2.Text = UserManager.GetName(records.BallSwitchesGameId2) + "(" + records.BallSwitchesGameId2 + ")";
            lblBallSwitchesGame.Text = records.BallSwitchesGame.ToString();

            lblBallSwitchesRoundId1.Text = UserManager.GetName(records.BallSwitchesRoundId1) + "(" + records.BallSwitchesRoundId1 + ")";
            lblBallSwitchesRoundId2.Text = UserManager.GetName(records.BallSwitchesRoundId2) + "(" + records.BallSwitchesRoundId2 + ")";
            lblBallSwitchesRound.Text = records.BallSwitchesRound.ToString();

            lblMostScoresId.Text = UserManager.GetName(records.MostScoresId) + "(" + records.MostScoresId + ")";
            lblMostScores.Text = records.MostScores.ToString();

            lblMostScoresInGameId1.Text = UserManager.GetName(records.MostScoresInGameId1) + "(" + records.MostScoresInGameId1 + ")";
            lblMostScoresInGameId2.Text = UserManager.GetName(records.MostScoresInGameId2) + "(" + records.MostScoresInGameId2 + ")";
            lblMostScoresInGame.Text = records.MostScoresInGame.ToString();
        }
    }
}
