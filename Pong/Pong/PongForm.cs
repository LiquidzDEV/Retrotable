using System;
using System.Drawing;
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
            Main.Player1 = new Player(true, pnlPlayer1, lblPlayer1);
            Main.Player2 = new Player(false, pnlPlayer2, lblPlayer2);
            Main.Ball = new Ball(main, pBall);
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

#if DEBUG
        private DateTime TickTime = DateTime.Now;
#endif
        private void timerBall_Tick(object sender, EventArgs e)
        {
            if (Main.Started)
                Main.Ball.Move();

#if DEBUG
            var newTime = DateTime.Now;
            lblDebug.Text = "Ballspeed: " + Main.Ball.Speed + "\nAngle: " + Main.Ball.Angle + "\nTick: " + (newTime - TickTime).TotalMilliseconds;
            TickTime = newTime;
#endif
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            Main.Ball.IncreaseSpeed();
            Main.TimeLeft--;
            UserManager.Player1.PlayTimePong++;
            UserManager.Player2.PlayTimePong++;

            UpdateTime();

            //Spielzeit abgelaufen
            if (Main.TimeLeft <= 0)
            {
                if (Main.Player1.ScorePoints > Main.Player2.ScorePoints)
                {
                    lblWinner.Text = "Spieler 1 hat gewonnen!";
                    lblWinner.ForeColor = Color.FromArgb(255, 255, 0, 0);
                    if (Main.Player1.ScorePoints > Main.Records.MostScores)
                    {
                        lblWinner.Text += "\nNeuer Rekord Meiste Tore (Einzeln)";
                        Main.Records.MostScores = Main.Player1.ScorePoints;
                        Main.Records.MostScoresId = UserManager.Player1.Id;
                    }
                }
                else if (Main.Player1.ScorePoints < Main.Player2.ScorePoints)
                {
                    lblWinner.Text = "Spieler 2 hat gewonnen!";
                    lblWinner.ForeColor = Color.FromArgb(255, 0, 0, 255);
                    if (Main.Player2.ScorePoints > Main.Records.MostScores)
                    {
                        lblWinner.Text += "\nNeuer Rekord Meiste Tore (Einzeln)";
                        Main.Records.MostScores = Main.Player2.ScorePoints;
                        Main.Records.MostScoresId = UserManager.Player2.Id;
                    }
                }
                else
                {
                    lblWinner.Text = "Unentschieden!";
                    lblWinner.ForeColor = Color.FromArgb(255, 180, 180, 180);
                }

                if (Main.BallSwitchesGame > Main.Records.BallSwitchesGame)
                {
                    lblWinner.Text += "\nNeuer Rekord Meiste Ballwechsel (Spiel)";
                    Main.Records.BallSwitchesGame = Main.BallSwitchesGame;
                    Main.Records.BallSwitchesGameId1 = UserManager.Player1.Id;
                    Main.Records.BallSwitchesGameId2 = UserManager.Player2.Id;
                    Main.Records.Save();
                }

                if (Main.Player1.ScorePoints + Main.Player2.ScorePoints > Main.Records.MostScoresInGame)
                {
                    lblWinner.Text += "\nNeuer Rekord Meiste Tore (Spiel)";
                    Main.Records.MostScoresInGame = Main.Player1.ScorePoints + Main.Player2.ScorePoints;
                    Main.Records.MostScoresInGameId1 = UserManager.Player1.Id;
                    Main.Records.MostScoresInGameId2 = UserManager.Player2.Id;
                }

                //lblWinner.Visible = true;
                Main.ResetRound();
            }
        }

        internal void UpdateTime()
        {
            var time = new TimeSpan(0, 0, Main.TimeLeft);
            lblTime.Text = time.ToString(@"mm\:ss");
            //lblTime.Text = Math.Floor(time.TotalMinutes) + ":" + time.Seconds;
        }

        #endregion

        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals(' ') && !Retrotable.ArduinoMode)
            {
                Main.Start();
            }
        }

        private void MainFormSizeChanged(object sender, EventArgs e)
        {
            World.SetBounds(ClientSize.Height, ClientSize.Width);
            Main.Player1.Resize();
            Main.Player2.Resize();
            System.Diagnostics.Debug.WriteLine("Auflösung verändert. (" + ClientSize.Height + "/" + ClientSize.Width + ")");
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
                Main.ResetRound();
                timerPaddle.Start();


                Main.Player1.SetPanelHeight(UserManager.Player1.PanelSize);
                Main.Player2.SetPanelHeight(UserManager.Player2.PanelSize);
                Ball.SetSpeedLevel(UserManager.Player1.BallSpeed);
                lblWinner.Text = Retrotable.ArduinoMode ? "Drücken zum Starten" : "Leertaste zum Starten";
                tsBallSpeed.Text = "Ballgeschwindigkeit: " + UserManager.Player1.BallSpeed;
                tsPlayer1.Text = "Balkengröße Spieler1: " + UserManager.Player1.PanelSize + "px";
                tsPlayer2.Text = "Balkengröße Spieler2: " + UserManager.Player2.PanelSize + "px";
            }
            else
            {
                timerPaddle.Stop();
                timerBall.Stop();
                timerMain.Stop();
            }
            System.Diagnostics.Debug.WriteLine("Pongform Visible -> " + Visible);
        }

        internal void UpdateRecordDisplay()
        {
            tsBallSwitchGame.Text = "Meiste Ballwechsel (Spiel): " + Main.Records.BallSwitchesGame;
            tsBallSwitchRound.Text = "Meiste Ballwechsel (Runde): " + Main.Records.BallSwitchesRound;
        }

        #endregion
    }
}

