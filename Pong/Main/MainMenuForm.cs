using RetroTable.Board;
using RetroTable.Test;
using RetroTable.UserSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace RetroTable.Main
{
    public partial class MainMenuForm : Form
    {
        private List<UserButton> UserButtons = new List<UserButton>();

        private Timer InputDelay = new Timer();

        public MainMenuForm()
        {
            InitializeComponent();
            UpdateUserBar();

#if DEBUG
            new LiveGameDataTest().Show();
            new ArduinoDataTest().Show();
#endif

            Retrotable.onButtonReleased += Retrotable_onButtonReleased;
            Retrotable.onEncoderRotated += Retrotable_onEncoderRotated;

            InputDelay.Interval = 1000;
            InputDelay.Tick += InputDelay_Tick;
            InputDelay.Start();
        }

        private void InputDelay_Tick(object sender, EventArgs e)
        {
            InputDelay.Enabled = false;
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

        private void Retrotable_onButtonReleased(Board.PinMapping button)
        {
            if (!Visible || ActiveForm != this || InputDelay.Enabled) return;
            if (button == PinMapping.EncoderSW)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    //if (this.FindFocusedControl() is UserButton btn2)
                    //{
                    //    btn2.PerformClick();
                    //}
                    if (this.FindFocusedControl() is Button btn)
                    {
                        btn.PerformClick();
                    }
                });
            }
            else if (button == PinMapping.Player1Buttons)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (this.FindFocusedControl() is UserButton btn)
                    {
                        int userid = Int32.Parse(Regex.Match(btn.Name, @"\d+").Value);
                        var user = UserManager.GetUsers().Find(x => x.User_Id == userid);
                        ApplyPlayer1(user);
                    }
                });
            }
            else if (button == PinMapping.Player2Buttons)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (this.FindFocusedControl() is UserButton btn)
                    {
                        int userid = Int32.Parse(Regex.Match(btn.Name, @"\d+").Value);
                        var user = UserManager.GetUsers().Find(x => x.User_Id == userid);
                        ApplyPlayer2(user);
                    }
                });
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            new UserMenuForm(null).Show();
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
                userButton.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
                userButton.Location = new Point(10 + 135 * (i + 1), 10);
                userButton.Name = "btnUser" + user.User_Id;
                userButton.Size = new Size(125, 125);
                userButton.TabIndex = 4 + i;
                userButton.Text = user.Name;
                userButton.UseVisualStyleBackColor = true;
                userButton.Click += UserButton_Click;
                userButton.MouseUp += UserButton_MouseUp;
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

        private void UserButton_Click(object sender, EventArgs e)
        {
            int userid = Int32.Parse(Regex.Match(((UserButton)sender).Name, @"\d+").Value);
            var user = UserManager.GetUsers().Find(x => x.User_Id == userid);

            if (user == null) return;

            System.Diagnostics.Debug.WriteLine("Button3");
            new UserMenuForm(user).Show();
        }

        private void UserButton_MouseUp(object sender, MouseEventArgs e)
        {
            int userid = Int32.Parse(Regex.Match(((UserButton)sender).Name, @"\d+").Value);
            var user = UserManager.GetUsers().Find(x => x.User_Id == userid);

            if (user == null) return;

            switch (e.Button)
            {
                case MouseButtons.Middle:
                    System.Diagnostics.Debug.WriteLine("Middle");
                    ApplyPlayer1(user);
                    break;
                case MouseButtons.Right:
                    System.Diagnostics.Debug.WriteLine("Rechts");
                    ApplyPlayer2(user);
                    break;
            }
        }

        private void ApplyPlayer1(User user)
        {
            ArduinoHelper.StartBlinking(true, 10, 100);
            UserManager.Player1 = user;
            if (UserManager.Player2 == user)
                UserManager.Player2 = null;
            UpdateUserBar();
        }

        private void ApplyPlayer2(User user)
        {
            ArduinoHelper.StartBlinking(false, 10, 100);
            UserManager.Player2 = user;
            if (UserManager.Player1 == user)
                UserManager.Player1 = null;
            UpdateUserBar();
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

        private void MainMenuForm_Activated(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("MainForm Aktiv");
            UpdateUserBar();
        }

        private void MainMenuForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxClick.Show(Location.X + e.Location.X, Location.Y + e.Location.Y);
            }
        }

        private void vollbildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            vollbildToolStripMenuItem.Checked = WindowState == FormWindowState.Maximized;
        }

        private void schliessenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Retrotable.Arduino.Close();
            Application.Exit();
        }
    }
}
