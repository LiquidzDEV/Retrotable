using RetroTable.Test;
using RetroTable.UserSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroTable.Main
{
    public partial class MainMenuForm : Form
    {
        private List<UserButton> UserButtons = new List<UserButton>();

        public MainMenuForm()
        {
            InitializeComponent();
            UpdateUserBar();
#if DEBUG
            new LiveGameDataTest().Show();
            new ArduinoDataTest().Show();
#endif

            Retrotable.onButtonReleased += Retrotable_onButtonReleased;
        }

        private void Retrotable_onButtonReleased(Board.PinMapping button)
        {
            if(button == Board.PinMapping.EncoderSW)
            {
                if(FindFocusedControl(this) is Button btn)
                {
                    btn.PerformClick();
                }
            }
        }

        public static Control FindFocusedControl(Control control)
        {
            var container = control as IContainerControl;
            while (container != null)
            {
                control = container.ActiveControl;
                container = control as IContainerControl;
            }
            return control;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (new UserMenuForm(null).ShowDialog() == DialogResult.OK)
                UpdateUserBar();
        }

        internal void UpdateUserBar()
        {
            //pnlUser.Width = 145 + Users.Count * 125;
            var users = UserManager.GetUsers();

            for (int i = UserButtons.Count - 1; i > 0; i--)
            {
                var button = UserButtons[i];
                if (users.Find(x => x.User_Id == button.GetUserId()) != null) continue;
                pnlUser.Controls.Remove(button);
                button.Dispose();
                UserButtons.Remove(button);
            }

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];

                if (UserButtons.Find(x => x.GetUserId() == user.User_Id) != null) continue;

                var userButton = new UserButton();
                userButton.FlatStyle = FlatStyle.Flat;
                userButton.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                userButton.Location = new Point(10 + 135 * (i + 1), 10);
                userButton.Name = "btnUser" + user.User_Id;
                userButton.Size = new Size(125, 125);
                userButton.TabIndex = 4 + i;
                userButton.Text = user.Name;
                userButton.UseVisualStyleBackColor = true;
                userButton.MouseUp += new MouseEventHandler(btnUser_Click);

                pnlUser.Controls.Add(userButton);
                UserButtons.Add(userButton);
            }

            UserButtons.ForEach(x => x.BackColor = System.Drawing.SystemColors.Control);

            if (UserManager.Player1 != null)
            {
                UserButtons.Find(x => x.GetUserId() == UserManager.Player1.User_Id).BackColor = Color.FromArgb(255, 119, 0, 0);
            }
            if (UserManager.Player2 != null)
            {
                UserButtons.Find(x => x.GetUserId() == UserManager.Player2.User_Id).BackColor = Color.FromArgb(255, 0, 0, 119);
            }

            btnAddUser.Location = new Point(10, 10);
        }


        private void btnUser_Click(object sender, MouseEventArgs e)
        {
            int userid = Int32.Parse(Regex.Match(((UserButton)sender).Name, @"\d+").Value);
            var user = UserManager.GetUsers().Find(x => x.User_Id == userid);

            if (user == null) return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    new UserMenuForm(user).ShowDialog();
                    break;
                case MouseButtons.Middle:
                    System.Diagnostics.Debug.WriteLine("Middle");
                    UserManager.Player1 = user;
                    if (UserManager.Player2 == user)
                        UserManager.Player2 = null;
                    UpdateUserBar();
                    break;
                case MouseButtons.Right:
                    System.Diagnostics.Debug.WriteLine("Rechts");
                    UserManager.Player2 = user;
                    if (UserManager.Player1 == user)
                        UserManager.Player1 = null;
                    UpdateUserBar();
                    break;
            }
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Retrotable.ArduinoMode)
                Retrotable.Arduino.Close();
        }

        private void btnPong_Click(object sender, EventArgs e)
        {
            if (UserManager.Player1 == null || UserManager.Player2 == null)
            {
                SetInfoLabel("Es müssen zwei Spieler ausgewählt sein, damit Pong gestartet werden kann");
                return;
            }

            Retrotable.Instance.Pong.Show();
        }

        private void btnBounce_Click(object sender, EventArgs e)
        {
            if (UserManager.Player1 == null)
            {
                SetInfoLabel("Es muss ein Spieler ausgewählt sein, damit Prellball gestartet werden kann");
                return;
            }

            Retrotable.Instance.Bounce.Show();
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
