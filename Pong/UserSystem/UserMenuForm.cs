using RetroTable.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroTable.UserSystem
{
    public partial class UserMenuForm : Form
    {
        public UserMenuForm()
        {
            InitializeComponent();
        }

        private void trbBallSpeed_Scroll(object sender, EventArgs e)
        {
            lblBallSpeed.Text = (trbBallSpeed.Value / 100f).ToString("N2") + "";
        }

        private void trbPanelSize_Scroll(object sender, EventArgs e)
        {
            lblPanelSize.Text = trbPanelSize.Value + "px";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var user = Retrotable.Instance.UserManager.CreateUser(txtName.Text);

            if (user == null)
            {
                lblInfo.Text = "Dieser Name ist bereits vergeben";
                return;
            }

            user.BallSpeed = trbBallSpeed.Value / 100f;
            user.PanelSize = trbPanelSize.Value;
            user.Save();
            Close();
        }
    }
}
