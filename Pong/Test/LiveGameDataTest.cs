using RetroTable.Main;
using RetroTable.UserSystem;
using System;
using System.Windows.Forms;

namespace RetroTable.Test
{
    public partial class LiveGameDataTest : Form
    {
        public LiveGameDataTest()
        {
            InitializeComponent();
            timerMain.Start();
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            lblRunning.Text = Retrotable.LiveGameData.running.ToString();
            lblTimeLeft.Text = Retrotable.LiveGameData.timeleft.ToString();
            lblUser1.Text = UserManager.GetName(Retrotable.LiveGameData.userId1) + "(" + Retrotable.LiveGameData.userId1 + ")";
            lblScore1.Text = Retrotable.LiveGameData.score1.ToString();
            lblUser2.Text = UserManager.GetName(Retrotable.LiveGameData.userId2) + "(" + Retrotable.LiveGameData.userId2 + ")";
            lblScore2.Text = Retrotable.LiveGameData.score2.ToString();
        }
    }
}
