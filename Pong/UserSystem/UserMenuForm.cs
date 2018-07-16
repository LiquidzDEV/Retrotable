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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtName.Text.Trim().Length < 3)
            {
                SetInfoLabel("Der Name muss min. drei Zeichen lang sein");
                return;
            }

            if (User == null)
            {
                var user = UserManager.CreateUser(txtName.Text);

                if (user == null)
                {
                    SetInfoLabel("Dieser Name ist bereits vergeben");
                    return;
                }

                user.BallSpeed = trbBallSpeed.Value / 100f;
                user.PanelSize = trbPanelSize.Value;
                user.Save();
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                //TODO if (Database.User.UserHasName(name) != null) return null;

                if (!txtName.Text.Equals(User.Name))
                {
                    if (UserManager.GetUsers().Find(x => x.Name == txtName.Text) != null)
                    {
                        SetInfoLabel("Dieser Name ist bereits vergeben");
                        return;
                    }
                    User.Name = txtName.Text;
                }

                User.BallSpeed = trbBallSpeed.Value / 100f;
                User.PanelSize = trbPanelSize.Value;
                User.Save();
                Close();
            }
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
    }
}
