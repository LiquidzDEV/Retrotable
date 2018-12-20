using RetroTable.Main;
using RetroTable.MySql;
using System;
using System.Windows.Forms;

namespace RetroTable.UserSystem
{
    public partial class UserMenuForm : Form
    {
        private User User;

        private Timer InputDelay = new Timer();

        public UserMenuForm(User user)
        {
            User = user;
            InitializeComponent();

            if (User != null)
            {
                Text = "Benutzer bearbeiten | ID: " + User.User_Id;
                txtName.Text = User.Name;
                trbBallSpeed.Value = (int)(User.Ball_Speed * 100);
                trbPanelSize.Value = User.Panel_Size;
                trbTimeLimit.Value = User.Time_Limit;

                lblMadeGoals.Text = "Erzielte Tore: " + User.MadeGoals_Pong;
                lblTakenGoals.Text = "Kassierte Tore: " + User.TakenGoals_Pong;
                lblDefended.Text = "Abgewehrte Bälle: " + User.DefendTimes_Pong;
                TimeSpan playTime = new TimeSpan(0, 0, User.PlayTime_Pong);
                lblPlayTime.Text = Math.Floor(playTime.TotalMinutes) + " Minuten " + playTime.Seconds + " Sekunden";
            }

            Retrotable.onEncoderRotated += Retrotable_onEncoderRotated;
            Retrotable.onButtonReleased += Retrotable_onButtonReleased;

            InputDelay.Interval = 1000;
            InputDelay.Tick += InputDelay_Tick;
            InputDelay.Start();
        }

        private void InputDelay_Tick(object sender, EventArgs e)
        {
            InputDelay.Enabled = false;
        }

        private void Retrotable_onButtonReleased(Board.PinMapping button)
        {
            if (!Visible || ActiveForm != this || InputDelay.Enabled) return;

            if (button == Board.PinMapping.EncoderSW)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (this.FindFocusedControl() is Button btn)
                    {
                        btn.PerformClick();
                    }
                });
            }
        }

        private void Retrotable_onEncoderRotated(bool clockwise)
        {
            if (!Visible || ActiveForm != this) return;
            this.Invoke((MethodInvoker)delegate
            {
                if (clockwise)
                    SelectNextControl(this.FindFocusedControl(), true, true, true, true);
                else
                    SelectNextControl(this.FindFocusedControl(), false, true, true, true);
            });
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
            User.Ball_Speed = trbBallSpeed.Value / 100f;
            User.Panel_Size = trbPanelSize.Value;
            User.Time_Limit = trbTimeLimit.Value;
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
