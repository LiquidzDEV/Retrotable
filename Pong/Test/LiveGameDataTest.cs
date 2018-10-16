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
            lblRunning.Text = Retrotable.LiveGameData.Running.ToString();
            lblTimeLeft.Text = Retrotable.LiveGameData.Timeleft.ToString();
            lblUser1.Text = UserManager.GetName(Retrotable.LiveGameData.User_Id1) + "(" + Retrotable.LiveGameData.User_Id1 + ")";
            lblScore1.Text = Retrotable.LiveGameData.Score1.ToString();
            lblUser2.Text = UserManager.GetName(Retrotable.LiveGameData.User_Id2) + "(" + Retrotable.LiveGameData.User_Id2 + ")";
            lblScore2.Text = Retrotable.LiveGameData.Score2.ToString();
        }
    }
}
