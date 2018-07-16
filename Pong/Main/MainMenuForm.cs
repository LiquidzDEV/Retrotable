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
        private List<Button> UserButtons = new List<Button>();

        public MainMenuForm()
        {
            InitializeComponent();
            UpdateUserBar();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (new UserMenuForm(null).ShowDialog() == DialogResult.OK)
                UpdateUserBar();
        }

        internal void UpdateUserBar()
        {
            var Users = UserManager.GetUsers();

            //pnlUser.Width = 145 + Users.Count * 125;

            foreach (var button in UserButtons)
            {
                pnlUser.Controls.Remove(button);
                button.Dispose();
            }
            UserButtons = new List<Button>();

            var users = UserManager.GetUsers();

            for (int i = 0; i < users.Count; i++)
            {
                var user = users[i];

                var userButton = new Button();
                userButton.FlatStyle = FlatStyle.Flat;
                userButton.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                userButton.Location = new Point(10 + (135 * i), 10);
                userButton.Name = "btnUser" + user.Id;
                userButton.Size = new Size(125, 125);
                userButton.TabIndex = i;
                userButton.Text = user.Name;
                userButton.UseVisualStyleBackColor = true;
                userButton.MouseUp += new MouseEventHandler(btnUser_Click);

                if (UserManager.Player1 != null && UserManager.Player1 == user)
                {
                    userButton.BackColor = Color.FromArgb(255, 119, 0, 0);
                }
                else if (UserManager.Player2 != null && UserManager.Player2 == user)
                {
                    userButton.BackColor = Color.FromArgb(255, 0, 0, 119);
                }

                pnlUser.Controls.Add(userButton);
                UserButtons.Add(userButton);
            }

            btnAddUser.Location = new Point(10 + Users.Count * 135, 10);
        }


        private void btnUser_Click(object sender, MouseEventArgs e)
        {
            int userid = Int32.Parse(Regex.Match(((Button)sender).Name, @"\d+").Value);
            var user = UserManager.GetUsers().Find(x => x.Id == userid);

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
    }
}
