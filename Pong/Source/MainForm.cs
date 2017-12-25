using System;
using System.Linq;
using System.Windows.Forms;
using LattePanda.Firmata;
using Pong.Source.Components;

namespace Pong.Source
{
    /// <summary>
    /// This is the Form of our application.
    /// It holds the visual appereance that the user will see and manages the input handling from the Keyboard and Arduino.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly Pong _main;

        /// <inheritdoc />
        /// <summary> Constructor of the <see cref="T:Pong.Source.MainForm" />. Initializes the components and adds the DigitalPinUpdated Event. </summary>
        public MainForm()
        {
            _main = Pong.Instance;

            if (Pong.ArduinoMode)
                Pong.Arduino.DigitalPinUpdated += DigitalPinUpdated;

            InitializeComponent();
            World.setBounds(ClientSize.Height, ClientSize.Width);
            _main.Player1 = new Player(pnlPlayer1, lblPlayer1);
            _main.Player2 = new Player(pnlPlayer2, lblPlayer2);
            _main.Ball = new Ball(pBall);
        }

        /// <summary> This Event is triggered when a digital pin is updated. </summary>
        /// <param name="pin"> The updated Pin </param>
        /// <param name="state"> the changed Value (HIGH or LOW) </param>
        private static void DigitalPinUpdated(PinMapping pin, byte state)
        {
            if (pin == PinMapping.ButtonStart && state == Arduino.HIGH && !Pong.Instance.Started)
            {
                ArduinoHelper.SetStartLeds(false, false);
                ArduinoHelper.StopBlinking();
                Pong.Instance.Ball.Start();
                Pong.Instance.Started = true;
            }
        }

        /// <summary> Triggered when the Form is loading. </summary>
        private void MainFormLoad(object sender, EventArgs e)
        {
            tsBallSlow.Checked = Properties.Settings.Default.ballSlow;
            tsBallNormal.Checked = Properties.Settings.Default.ballNormal;
            tsBallFast.Checked = Properties.Settings.Default.ballFast;
            tsBalkenSchmal.Checked = Properties.Settings.Default.panelSmall;
            tsBalkenNormal.Checked = Properties.Settings.Default.panelNormal;
            tsBalkenBreit.Checked = Properties.Settings.Default.panelBig;

            ResetRound();
            timerPaddle.Start();
            timerBall.Start();

            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        /// <summary> Triggered when the Form is closing (not closed!). </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.ballSlow = tsBallSlow.Checked;
            Properties.Settings.Default.ballNormal = tsBallNormal.Checked;
            Properties.Settings.Default.ballFast = tsBallFast.Checked;
            Properties.Settings.Default.panelSmall = tsBalkenSchmal.Checked;
            Properties.Settings.Default.panelNormal = tsBalkenNormal.Checked;
            Properties.Settings.Default.panelBig = tsBalkenBreit.Checked;
            Properties.Settings.Default.Save();

            if (Pong.ArduinoMode)
                Pong.Arduino.Close();
        }

        #region Bewegen der Balken

        void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            SetMovingState(e.KeyCode, true);
        }

        void MainFormKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
            else if (e.KeyCode == Keys.F12)
                WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;

            SetMovingState(e.KeyCode, false);
        }

        private void SetMovingState(Keys keycode, bool isKeyDown)
        {
            if (!Pong.ArduinoMode)
            {
                switch (keycode)
                {
                    case Keys.W:
                        _main.Player1.playerUp = isKeyDown;
                        break;
                    case Keys.S:
                        _main.Player1.playerDown = isKeyDown;
                        break;

                    case Keys.Up:
                        _main.Player2.playerUp = isKeyDown;
                        break;
                    case Keys.Down:
                        _main.Player2.playerDown = isKeyDown;
                        break;
                }
            }
        }

        void timerPaddle_Tick(object sender, EventArgs e)
        {
            _main.Player1.Move();
            _main.Player2.Move();
        }

        #endregion

        #region Ball

        private void timerBall_Tick(object sender, EventArgs e)
        {
            if (_main.Started)
                _main.Ball.Move();
        }

        private void timerIncreaseSpeed_Tick(object sender, EventArgs e)
        {
            _main.Ball.IncreaseSpeed();
        }

        #endregion

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(' ') && !_main.Started && !Pong.ArduinoMode)
            {
                _main.Ball.Start();
                timerIncreaseSpeed.Start();
                _main.Started = true;
            }
        }

        private void MainFormSizeChanged(object sender, EventArgs e)
        {
            World.setBounds(ClientSize.Height, ClientSize.Width);
            _main.Player1.resize();
            _main.Player2.resize();
            Pong.DebugMessage("Auflösung verändert. (" + ClientSize.Height + "/" + ClientSize.Width + ")");
        }

        public void ResetRound()
        {
            _main.Started = false;
            timerIncreaseSpeed.Stop();
            _main.Player1.reset();
            _main.Player2.reset();
            _main.Ball.Reset();
            Pong.DebugMessage("Spiel wurde zurückgesetzt.");
        }

        #region MenuStrip

        private void ToolStripCheckOnlyOne(object sender, EventArgs e)
        {
            if (sender == null) return;

            var currentItem = (ToolStripMenuItem)sender;

            ((ToolStripMenuItem)currentItem.OwnerItem).DropDownItems.OfType<ToolStripMenuItem>().ToList()
                .ForEach(item =>
                {
                    if (item.Checked && !item.Equals(currentItem))
                    {
                        item.Checked = false;
                    }
                });
        }

        private void ToolStrip_CheckedChanged(object sender, EventArgs e)
        {
            /*
 			* C# >= 7.0
			* if (!(sender is ToolStripMenuItem currentItem)) return;
            * 
            * C# < 7.0
            * if (sender == null) return;
            * var currentItem = (ToolStripMenuItem)sender;
			*/

            if (!(sender is ToolStripMenuItem currentItem)) return;

            if (!currentItem.Checked) return;

            if (currentItem.Equals(tsBalkenSchmal))
            {
                _main.Player1.setPanelHeight(Player.PANEL_SMALL);
                _main.Player2.setPanelHeight(Player.PANEL_SMALL);
            }
            else if (currentItem.Equals(tsBalkenNormal))
            {
                _main.Player1.setPanelHeight(Player.PANEL_NORMAL);
                _main.Player2.setPanelHeight(Player.PANEL_NORMAL);
            }
            else if (currentItem.Equals(tsBalkenBreit))
            {
                _main.Player1.setPanelHeight(Player.PANEL_BIG);
                _main.Player2.setPanelHeight(Player.PANEL_BIG);
            }
            else if (currentItem.Equals(tsBallSlow))
            {
                Ball.SetSpeedLevel(2);
            }
            else if (currentItem.Equals(tsBallNormal))
            {
                Ball.SetSpeedLevel(3);
            }
            else if (currentItem.Equals(tsBallFast))
            {
                Ball.SetSpeedLevel(4);
            }
        }
    }
    #endregion
}

