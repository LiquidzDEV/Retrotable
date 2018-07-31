using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroTable.Bounce
{
    public partial class BounceForm : Form
    {
        private Bounce Main;

        public BounceForm(Bounce main)
        {
            Main = main;
            InitializeComponent();
        }

        public new void Hide()
        {

            base.Hide();
            timerPaddle.Stop();
        }

        public new void Show()
        {
            Main.Player.Location = new Point(16, Height / 2 - Main.Player.Bounds.Height / 2);
            Main.Ball.Location = new Point(Width / 2 - Main.Ball.Bounds.Width / 2, Height / 2 - Main.Ball.Bounds.Height / 2);
            timerPaddle.Start();
            base.Show();
        }

        private void BounceForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Main.Player.SetMoveSet(true, false);
                    break;
                case Keys.S:
                    Main.Player.SetMoveSet(false, false);
                    break;
                case Keys.Escape:
                    Hide();
                    break;
            }
        }

        private void BounceForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    Main.Player.SetMoveSet(true, true);
                    break;
                case Keys.S:
                    Main.Player.SetMoveSet(false, true);
                    break;
            }
        }

        private void timerPaddle_Tick(object sender, EventArgs e)
        {
            Main.Player.Move();
        }
    }
}
