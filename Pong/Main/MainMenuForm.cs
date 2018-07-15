using RetroTable.UserSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroTable.Main
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
            UpdateUserBar();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            new UserMenuForm().ShowDialog();
        }

        internal void UpdateUserBar()
        {
            var Users = Retrotable.Instance.UserManager.GetUsers();

            pnlUser.Width = 145 + Users.Count * 125;

            btnAddUser.Location = new Point(10 + Users.Count * 125, 10);
        }

        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Retrotable.ArduinoMode)
                Retrotable.Arduino.Close();
        }
    }
}
