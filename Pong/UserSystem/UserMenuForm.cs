using RetroTable.Main;
using RetroTable.MySql;
using System;
using System.Windows.Forms;

namespace RetroTable.UserSystem
{
    public partial class UserMenuForm : Form
    {
        User User;

        public UserMenuForm(User user)
        {
            User = user;
            InitializeComponent();

            if (User != null)
            {
                Text = "Benutzer bearbeiten | ID: " + User.Id;
                txtName.Text = User.Name;
                trbBallSpeed.Value = (int)(User.BallSpeed * 100);
                trbPanelSize.Value = User.PanelSize;
                trbTimeLimit.Value = User.TimeLimit;

                lblMadeGoals.Text = "Erzielte Tore: " + User.MadeGoalsPong;
                lblTakenGoals.Text = "Kassierte Tore: " + User.TakenGoalsPong;
                lblDefended.Text = "Abgewehrte Bälle: " + User.DefendTimesPong;
                TimeSpan playTime = new TimeSpan(0, 0, User.PlayTimePong);
                lblPlayTime.Text = Math.Floor(playTime.TotalMinutes) + " Minuten " + playTime.Seconds + " Sekunden";
            }
        }

        private void trbBallSpeed_ValueChanged(object sender, EventArgs e)
        {
            lblBallSpeed.Text = (trbBallSpeed.Value / 100f).ToString("N2") + "";
        }

        private void trbPanelSize_ValueChanged(object sender, EventArgs e)
        {
            lblPanelSize.Text = trbPanelSize.Value + "px";
        }

        private void trbTimeLimit_ValueChanged(object sender, EventArgs e)
        {
            lblTimeLimit.Text = trbTimeLimit.Value + " Minuten";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                SetInfoLabel("Der Name muss min. drei Zeichen lang sein");
                return;
            }

            if (User == null)
            {
                User = UserManager.CreateUser(txtName.Text);

                if (User == null)
                {
                    SetInfoLabel("Dieser Name ist bereits vergeben");
                    return;
                }
            }
            else
            {
                if (!txtName.Text.Equals(User.Name))
                {
                    if ((Retrotable.Databasemode && Database.User.UserHasName(txtName.Text) != null) || UserManager.GetUsers().Find(x => x.Name == txtName.Text) != null)
                    {
                        SetInfoLabel("Dieser Name ist bereits vergeben");
                        return;
                    }
                    User.Name = txtName.Text;
                }
            }
            User.BallSpeed = trbBallSpeed.Value / 100f;
            User.PanelSize = trbPanelSize.Value;
            User.TimeLimit = trbTimeLimit.Value;
            User.Save();
            DialogResult = DialogResult.OK;
            Close();
        }

        private Timer timer;
        private void SetInfoLabel(string text)
        {
            timer?.Stop();

            lblInfo.Text = text;

            if (timer == null)
            {
                timer = new Timer()
                {
                    Interval = 3000,
                };
            }

            timer.Start();

            timer.Tick += (object sender, EventArgs e) =>
            {
                lblInfo.Text = "";
            };
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (User != null && User.Name == txtName.Text)
            {
                btnSave.Enabled = true;
                return;
            }

            btnSave.Enabled = UserManager.GetUsers().Find(x => x.Name.ToLower() == txtName.Text.ToLower()) == null;
        }
    }
}
