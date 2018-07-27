/*
 * Pascal "Liquidz" H.
 * 10.02.2017 / 07:47
 * 
 * Description:
 */
namespace RetroTable.Pong
{
    partial class PongForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PongForm));
            this.pnlPlayer1 = new System.Windows.Forms.Panel();
            this.pnlPlayer2 = new System.Windows.Forms.Panel();
            this.timerPaddle = new System.Windows.Forms.Timer(this.components);
            this.pBall = new System.Windows.Forms.PictureBox();
            this.lblPlayer1 = new System.Windows.Forms.Label();
            this.lblPlayer2 = new System.Windows.Forms.Label();
            this.timerBall = new System.Windows.Forms.Timer(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ctxtMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsFullscreen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsClose = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblWinner = new System.Windows.Forms.Label();
            this.spieleinstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPlayer1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPlayer2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBallSpeed = new System.Windows.Forms.ToolStripMenuItem();
            this.rekordeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBallSwitchGame = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMostScores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMostScoresTotal = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBallSwitchRound = new System.Windows.Forms.ToolStripMenuItem();
            this.lblDebug = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pBall)).BeginInit();
            this.ctxtMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPlayer1
            // 
            this.pnlPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pnlPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pnlPlayer1.Location = new System.Drawing.Point(16, 214);
            this.pnlPlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlayer1.Name = "pnlPlayer1";
            this.pnlPlayer1.Size = new System.Drawing.Size(20, 154);
            this.pnlPlayer1.TabIndex = 0;
            // 
            // pnlPlayer2
            // 
            this.pnlPlayer2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pnlPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.pnlPlayer2.Location = new System.Drawing.Point(1008, 214);
            this.pnlPlayer2.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPlayer2.Name = "pnlPlayer2";
            this.pnlPlayer2.Size = new System.Drawing.Size(20, 154);
            this.pnlPlayer2.TabIndex = 1;
            // 
            // timerPaddle
            // 
            this.timerPaddle.Interval = 30;
            this.timerPaddle.Tick += new System.EventHandler(this.timerPaddle_Tick);
            // 
            // pBall
            // 
            this.pBall.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pBall.BackColor = System.Drawing.Color.Transparent;
            this.pBall.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBall.BackgroundImage")));
            this.pBall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pBall.Location = new System.Drawing.Point(512, 281);
            this.pBall.Margin = new System.Windows.Forms.Padding(4);
            this.pBall.Name = "pBall";
            this.pBall.Size = new System.Drawing.Size(21, 20);
            this.pBall.TabIndex = 2;
            this.pBall.TabStop = false;
            // 
            // lblPlayer1
            // 
            this.lblPlayer1.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPlayer1.Location = new System.Drawing.Point(258, 9);
            this.lblPlayer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayer1.Name = "lblPlayer1";
            this.lblPlayer1.Size = new System.Drawing.Size(199, 46);
            this.lblPlayer1.TabIndex = 4;
            this.lblPlayer1.Text = "0\r\nSpieler1";
            this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPlayer2
            // 
            this.lblPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
            this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.lblPlayer2.Location = new System.Drawing.Point(587, 9);
            this.lblPlayer2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPlayer2.Name = "lblPlayer2";
            this.lblPlayer2.Size = new System.Drawing.Size(199, 46);
            this.lblPlayer2.TabIndex = 5;
            this.lblPlayer2.Text = "0\r\nSpieler2";
            this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerBall
            // 
            this.timerBall.Interval = 10;
            this.timerBall.Tick += new System.EventHandler(this.timerBall_Tick);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(464, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "Score";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctxtMenu
            // 
            this.ctxtMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFullscreen,
            this.tsClose,
            this.spieleinstellungenToolStripMenuItem,
            this.rekordeToolStripMenuItem});
            this.ctxtMenu.Name = "ctxtMenu";
            this.ctxtMenu.Size = new System.Drawing.Size(181, 114);
            // 
            // tsFullscreen
            // 
            this.tsFullscreen.Checked = true;
            this.tsFullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsFullscreen.Name = "tsFullscreen";
            this.tsFullscreen.Size = new System.Drawing.Size(180, 22);
            this.tsFullscreen.Text = "Vollbild";
            this.tsFullscreen.Click += new System.EventHandler(this.tsFullscreen_Click);
            // 
            // tsClose
            // 
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(180, 22);
            this.tsClose.Text = "Schliessen";
            this.tsClose.Click += new System.EventHandler(this.tsClose_Click);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTime.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.Gray;
            this.lblTime.Location = new System.Drawing.Point(464, 32);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(116, 23);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "10:00";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWinner
            // 
            this.lblWinner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWinner.AutoSize = true;
            this.lblWinner.BackColor = System.Drawing.Color.Transparent;
            this.lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWinner.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblWinner.Location = new System.Drawing.Point(501, 159);
            this.lblWinner.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblWinner.Name = "lblWinner";
            this.lblWinner.Size = new System.Drawing.Size(43, 46);
            this.lblWinner.TabIndex = 8;
            this.lblWinner.Text = "0";
            this.lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // spieleinstellungenToolStripMenuItem
            // 
            this.spieleinstellungenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPlayer1,
            this.tsPlayer2,
            this.tsBallSpeed});
            this.spieleinstellungenToolStripMenuItem.Name = "spieleinstellungenToolStripMenuItem";
            this.spieleinstellungenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.spieleinstellungenToolStripMenuItem.Text = "Spieleinstellungen";
            // 
            // tsPlayer1
            // 
            this.tsPlayer1.Name = "tsPlayer1";
            this.tsPlayer1.Size = new System.Drawing.Size(187, 22);
            this.tsPlayer1.Text = "Breite Spieler 1: 150px";
            // 
            // tsPlayer2
            // 
            this.tsPlayer2.Name = "tsPlayer2";
            this.tsPlayer2.Size = new System.Drawing.Size(187, 22);
            this.tsPlayer2.Text = "Breite Spieler 2: 150px";
            // 
            // tsBallSpeed
            // 
            this.tsBallSpeed.Name = "tsBallSpeed";
            this.tsBallSpeed.Size = new System.Drawing.Size(187, 22);
            this.tsBallSpeed.Text = "Ballgeschwindigkeit: ";
            // 
            // rekordeToolStripMenuItem
            // 
            this.rekordeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBallSwitchGame,
            this.tsBallSwitchRound,
            this.tsMostScores,
            this.tsMostScoresTotal});
            this.rekordeToolStripMenuItem.Name = "rekordeToolStripMenuItem";
            this.rekordeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.rekordeToolStripMenuItem.Text = "Rekorde";
            // 
            // tsBallSwitchGame
            // 
            this.tsBallSwitchGame.Name = "tsBallSwitchGame";
            this.tsBallSwitchGame.Size = new System.Drawing.Size(221, 22);
            this.tsBallSwitchGame.Text = "Meiste Ballwechsel (Spiel): ";
            // 
            // tsMostScores
            // 
            this.tsMostScores.Name = "tsMostScores";
            this.tsMostScores.Size = new System.Drawing.Size(221, 22);
            this.tsMostScores.Text = "Meiste Tore (Spiel):";
            // 
            // tsMostScoresTotal
            // 
            this.tsMostScoresTotal.Name = "tsMostScoresTotal";
            this.tsMostScoresTotal.Size = new System.Drawing.Size(221, 22);
            this.tsMostScoresTotal.Text = "Meiste Tore (Einzeln):";
            // 
            // tsBallSwitchRound
            // 
            this.tsBallSwitchRound.Name = "tsBallSwitchRound";
            this.tsBallSwitchRound.Size = new System.Drawing.Size(221, 22);
            this.tsBallSwitchRound.Text = "Meiste Ballwechsel (Runde):";
            // 
            // lblDebug
            // 
            this.lblDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDebug.AutoSize = true;
            this.lblDebug.ForeColor = System.Drawing.Color.Red;
            this.lblDebug.Location = new System.Drawing.Point(205, 214);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(0, 13);
            this.lblDebug.TabIndex = 9;
            // 
            // PongForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1044, 583);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.lblWinner);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.pnlPlayer1);
            this.Controls.Add(this.pnlPlayer2);
            this.Controls.Add(this.pBall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPlayer2);
            this.Controls.Add(this.lblPlayer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1044, 583);
            this.Name = "PongForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
            this.VisibleChanged += new System.EventHandler(this.PongForm_VisibleChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyUp);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pBall)).EndInit();
            this.ctxtMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlayer1;
        private System.Windows.Forms.PictureBox pBall;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Timer timerPaddle;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip ctxtMenu;
        private System.Windows.Forms.ToolStripMenuItem tsFullscreen;
        private System.Windows.Forms.ToolStripMenuItem tsClose;
        internal System.Windows.Forms.Timer timerBall;
        internal System.Windows.Forms.Timer timerMain;
        internal System.Windows.Forms.Label lblWinner;
        internal System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.ToolStripMenuItem spieleinstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsPlayer1;
        private System.Windows.Forms.ToolStripMenuItem tsPlayer2;
        private System.Windows.Forms.ToolStripMenuItem tsBallSpeed;
        private System.Windows.Forms.ToolStripMenuItem rekordeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsBallSwitchGame;
        private System.Windows.Forms.ToolStripMenuItem tsBallSwitchRound;
        private System.Windows.Forms.ToolStripMenuItem tsMostScores;
        private System.Windows.Forms.ToolStripMenuItem tsMostScoresTotal;
        private System.Windows.Forms.Label lblDebug;
    }
}
