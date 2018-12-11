using RetroTable.Board;
using RetroTable.Main;
using RetroTable.Pong.Components;
using RetroTable.UserSystem;
using System;
using System.Drawing;
using System.Windows.Forms;

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

            Retrotable.onButtonPressed += RetroTable_onButtonPressed;
            Retrotable.onButtonReleased += Retrotable_onButtonReleased;

            InitializeComponent();
            World.SetBounds(ClientSize.Height, ClientSize.Width);
            Main.Player1 = new Player(true, pnlPlayer1, lblPlayer1);
            Main.Player2 = new Player(false, pnlPlayer2, lblPlayer2);
            Main.Ball = new Ball(main, pBall);
            Hide();
        }

        private bool Player1Pressed, Player2Pressed;

        private void RetroTable_onButtonPressed(PinMapping button)
        {
            if (!Visible) return;

            if (button == PinMapping.Player1Buttons)
                Player1Pressed = true;
            else if (button == PinMapping.Player2Buttons)
                Player2Pressed = true;

            if (Player1Pressed && Player2Pressed)
            {
                Main.Start();
            }
        }

        private void Retrotable_onButtonReleased(PinMapping button)
        {
            if (button == PinMapping.Player1Buttons)
                Player1Pressed = false;
            else if (button == PinMapping.Player2Buttons)
                Player2Pressed = false;
        }

        internal void ClearWinnerDisplay(bool withInfo)
        {
            lblMidPlayer1.NewText = "";
            lblMidPlayer2.NewText = "";

            if (withInfo)
            {
                lblInfoPlayer1.NewText = "";
                lblInfoPlayer2.NewText = "";
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

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            SetMovingState(e.KeyCode, true);
        }

        private void MainFormKeyUp(object sender, KeyEventArgs e)
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

        private void timerPaddle_Tick(object sender, EventArgs e)
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
            Retrotable.LiveGameData.Timeleft--;
            Retrotable.UpdateLiveGameData();
            UserManager.Player1.PlayTime_Pong++;
            UserManager.Player2.PlayTime_Pong++;

            UpdateTime();

            //Spielzeit abgelaufen
            if (Main.TimeLeft <= 0)
            {
                if (Main.Player1.ScorePoints > Main.Player2.ScorePoints)
                {
                    lblMidPlayer1.NewText = "Gewonnen!";
                    lblMidPlayer1.ForeColor = Color.FromArgb(255, 0, 192, 0);
                    lblMidPlayer2.NewText = "Verloren!";
                    lblMidPlayer2.ForeColor = Color.FromArgb(255, 192, 0, 0);
                    if (Main.Player1.ScorePoints > Main.Records.MostScores)
                    {
                        lblInfoPlayer1.NewText += "Neuer Rekord Meiste Tore (Einzeln)\n";

                        Main.Records.MostScores = Main.Player1.ScorePoints;
                        Main.Records.MostScores_Id = UserManager.Player1.User_Id;
                    }
                }
                else if (Main.Player1.ScorePoints < Main.Player2.ScorePoints)
                {
                    lblMidPlayer1.NewText = "Verloren!";
                    lblMidPlayer1.ForeColor = Color.FromArgb(255, 192, 0, 0);
                    lblMidPlayer2.NewText = "Gewonnen!";
                    lblMidPlayer2.ForeColor = Color.FromArgb(255, 0, 192, 0);
                    if (Main.Player2.ScorePoints > Main.Records.MostScores)
                    {
                        lblInfoPlayer2.NewText += "Neuer Rekord Meiste Tore (Einzeln)\n";
                        Main.Records.MostScores = Main.Player2.ScorePoints;
                        Main.Records.MostScores_Id = UserManager.Player2.User_Id;
                    }
                }
                else
                {
                    lblMidPlayer1.NewText = "Unentschieden!";
                    lblMidPlayer1.ForeColor = Color.FromArgb(255, 180, 180, 180);
                    lblMidPlayer2.NewText = "Unentschieden!";
                    lblMidPlayer2.ForeColor = Color.FromArgb(255, 180, 180, 180);
                }

                if (Main.BallSwitchesGame > Main.Records.BallSwitches_Game)
                {
                    lblInfoPlayer1.NewText += "Neuer Rekord Meiste Ballwechsel (Spiel)\n";
                    lblInfoPlayer2.NewText += "Neuer Rekord Meiste Ballwechsel (Spiel)\n";
                    Main.Records.BallSwitches_Game = Main.BallSwitchesGame;
                    Main.Records.BallSwitches_Game_Id1 = UserManager.Player1.User_Id;
                    Main.Records.BallSwitches_Game_Id2 = UserManager.Player2.User_Id;
                    Main.Records.Save();
                }

                if (Main.Player1.ScorePoints + Main.Player2.ScorePoints > Main.Records.MostScores_Game)
                {
                    lblInfoPlayer1.NewText += "Neuer Rekord Meiste Tore (Spiel)\n";
                    lblInfoPlayer2.NewText += "Neuer Rekord Meiste Tore (Spiel)\n";
                    Main.Records.MostScores_Game = Main.Player1.ScorePoints + Main.Player2.ScorePoints;
                    Main.Records.MostScores_Game_Id1 = UserManager.Player1.User_Id;
                    Main.Records.MostScores_Game_Id2 = UserManager.Player2.User_Id;
                    Main.Records.Save();
                }

                HistoryEntry.Create(UserManager.Player1, Main.Player1.ScorePoints, UserManager.Player2, Main.Player2.ScorePoints);

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

        internal new void Show()
        {
            //Main.ResetRound();
            timerPaddle.Start();

            Main.Player1.SetPanelHeight(UserManager.Player1.Panel_Size);
            Main.Player2.SetPanelHeight(UserManager.Player2.Panel_Size);
            Ball.SetSpeedLevel(UserManager.Player1.Ball_Speed);

            lblMidPlayer1.NewText = Retrotable.ArduinoMode ? "Drücken zum Starten" : "Leertaste zum Starten";
            lblMidPlayer1.ForeColor = Color.FromArgb(255, 180, 180, 0);
            lblMidPlayer2.NewText = Retrotable.ArduinoMode ? "Drücken zum Starten" : "Leertaste zum Starten";
            lblMidPlayer2.ForeColor = Color.FromArgb(255, 180, 180, 0);

            lblInfoPlayer1.NewText = " ";
            lblInfoPlayer2.NewText = " ";

            tsBallSpeed.Text = "Ballgeschwindigkeit: " + UserManager.Player1.Ball_Speed;
            tsPlayer1.Text = "Balkengröße Spieler1: " + UserManager.Player1.Panel_Size + "px";
            tsPlayer2.Text = "Balkengröße Spieler2: " + UserManager.Player2.Panel_Size + "px";

            base.Show();
        }

        internal new void Hide()
        {
            base.Hide();

            timerPaddle.Stop();
            timerBall.Stop();
            timerMain.Stop();
        }

        internal void UpdateRecordDisplay()
        {
            tsBallSwitchGame.Text = "Meiste Ballwechsel (Spiel): " + Main.Records.BallSwitches_Game;
            tsBallSwitchRound.Text = "Meiste Ballwechsel (Runde): " + Main.Records.BallSwitches_Round;
        }

        #endregion
    }
}

