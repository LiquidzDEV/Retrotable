using System;
using System.Linq;
using System.Windows.Forms;
using RetroTable.Board;
using RetroTable.Main;
using RetroTable.Pong.Components;
using RetroTable.UserSystem;

namespace RetroTable.Pong
{
    /// <summary>
    /// This is the Form of our application.
    /// It holds the visual appereance that the user will see and manages the input handling from the Keyboard and Arduino.
    /// </summary>
    public partial class PongForm : Form
    {
        private readonly Pong Main;

        /// <inheritdoc />
        /// <summary> Constructor of the <see cref="T:Pong.Source.MainForm" />. Initializes the components and adds the DigitalPinUpdated Event. </summary>
        public PongForm(Pong main)
        {
            Main = main;

            Retrotable.onButtonReleased += RetroTable_onButtonReleased;

            InitializeComponent();
            World.SetBounds(ClientSize.Height, ClientSize.Width);
            Main.Player1 = new Player(pnlPlayer1, lblPlayer1);
            Main.Player2 = new Player(pnlPlayer2, lblPlayer2);
            Main.Ball = new Ball(pBall);
            Hide();
        }

        private void RetroTable_onButtonReleased(PinMapping button)
        {
            if (!Visible) return;

            if (button == PinMapping.ButtonStart)
            {
                Main.Start();
            }
        }

        ///// <summary> This Event is triggered when a digital pin is updated. </summary>
        ///// <param name="pin"> The updated Pin </param>
        ///// <param name="state"> the changed Value (HIGH or LOW) </param>
        //private static void DigitalPinUpdated(PinMapping pin, byte state)
        //{
        //    if (pin == PinMapping.ButtonStart && state == Arduino.HIGH && !Retrotable.Instance.Started)
        //    {
        //        ArduinoHelper.SetStartLeds(false, false);
        //        ArduinoHelper.StopBlinking();
        //        Retrotable.Instance.Ball.Start();
        //        Retrotable.Instance.Started = true;
        //    }
        //}

        /// <summary> Triggered when the Form is loading. </summary>
        private void MainFormLoad(object sender, EventArgs e)
        {           
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary> Triggered when the Form is closing (not closed!). </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Main.Hide();
        }

        #region Bewegen der Balken

        void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            SetMovingState(e.KeyCode, true);
        }

        void MainFormKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Main.Hide();
            else if (e.KeyCode == Keys.F12)
            {
                WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
                tsFullscreen.Checked = WindowState == FormWindowState.Maximized;
            }

            SetMovingState(e.KeyCode, false);
        }

        private void SetMovingState(Keys keycode, bool isKeyDown)
        {
            if (!Retrotable.ArduinoMode)
            {
                switch (keycode)
                {
                    case Keys.W:
                        Main.Player1.PlayerUp = isKeyDown;
                        break;
                    case Keys.S:
                        Main.Player1.PlayerDown = isKeyDown;
                        break;

                    case Keys.Up:
                        Main.Player2.PlayerUp = isKeyDown;
                        break;
                    case Keys.Down:
                        Main.Player2.PlayerDown = isKeyDown;
                        break;
                }
            }
        }

        void timerPaddle_Tick(object sender, EventArgs e)
        {
            Main.Player1.Move();
            Main.Player2.Move();
        }

        #endregion

        #region Ball

        private void timerBall_Tick(object sender, EventArgs e)
        {
            if (Main.Started)
                Main.Ball.Move();
        }

        private void timerIncreaseSpeed_Tick(object sender, EventArgs e)
        {
            Main.Ball.IncreaseSpeed();
        }

        #endregion

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(' ') && !Retrotable.ArduinoMode)
            {
                Main.Start();
                timerIncreaseSpeed.Start();
            }
        }

        private void MainFormSizeChanged(object sender, EventArgs e)
        {
            World.SetBounds(ClientSize.Height, ClientSize.Width);
            Main.Player1.Resize(true);
            Main.Player2.Resize(false);
            System.Diagnostics.Debug.WriteLine("Auflösung verändert. (" + ClientSize.Height + "/" + ClientSize.Width + ")");
        }

        internal void ResetRound()
        {
            timerIncreaseSpeed.Stop();
        }

        #region ContextMenu

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxtMenu.Show(this.Location.X + e.Location.X, this.Location.Y + e.Location.Y);
            }
        }

        private void tsFullscreen_Click(object sender, EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            tsFullscreen.Checked = WindowState == FormWindowState.Maximized;
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Main.Hide();
        }

        private void PongForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                Main.Reset();
                timerPaddle.Start();
                timerBall.Start();

                Main.Player1.SetPanelHeight(UserManager.Player1.PanelSize);
                Main.Player2.SetPanelHeight(UserManager.Player2.PanelSize);
                Ball.SetSpeedLevel(UserManager.Player1.BallSpeed);
            }
            else
            {
                timerPaddle.Stop();
                timerBall.Stop();
            }
            System.Diagnostics.Debug.WriteLine("Pongform Visible -> " + Visible);
        }
    }
    #endregion
}

