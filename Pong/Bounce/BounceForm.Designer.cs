namespace RetroTable.Bounce
{
    partial class BounceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BounceForm));
            this.timerPaddle = new System.Windows.Forms.Timer(this.components);
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.timerBalls = new System.Windows.Forms.Timer(this.components);
            this.lblDebug = new System.Windows.Forms.Label();
            this.timerAddBall = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblRanking = new System.Windows.Forms.Label();
            this.pnlRanking = new System.Windows.Forms.Panel();
            this.lblOwnRecord = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblThird = new System.Windows.Forms.Label();
            this.lblSecond = new System.Windows.Forms.Label();
            this.lblFirst = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTime = new RetroTable.Main.RotatingLabel();
            this.lblScore = new RetroTable.Main.RotatingLabel();
            this.pnlRanking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timerPaddle
            // 
            this.timerPaddle.Interval = 20;
            this.timerPaddle.Tick += new System.EventHandler(this.timerPaddle_Tick);
            // 
            // timerMain
            // 
            this.timerMain.Interval = 1000;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // timerBalls
            // 
            this.timerBalls.Interval = 1;
            this.timerBalls.Tick += new System.EventHandler(this.timerBalls_Tick);
            // 
            // lblDebug
            // 
            this.lblDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDebug.AutoSize = true;
            this.lblDebug.BackColor = System.Drawing.Color.White;
            this.lblDebug.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDebug.ForeColor = System.Drawing.Color.Red;
            this.lblDebug.Location = new System.Drawing.Point(853, 9);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDebug.Size = new System.Drawing.Size(0, 12);
            this.lblDebug.TabIndex = 1;
            // 
            // timerAddBall
            // 
            this.timerAddBall.Interval = 5000;
            this.timerAddBall.Tick += new System.EventHandler(this.timerAddBall_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 26);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bestenliste:";
            // 
            // lblRanking
            // 
            this.lblRanking.AutoSize = true;
            this.lblRanking.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRanking.Location = new System.Drawing.Point(21, 130);
            this.lblRanking.Name = "lblRanking";
            this.lblRanking.Size = new System.Drawing.Size(75, 28);
            this.lblRanking.TabIndex = 7;
            this.lblRanking.Text = "4. Pascal: 400\r\n5. Test: 300\r\n";
            // 
            // pnlRanking
            // 
            this.pnlRanking.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlRanking.BackColor = System.Drawing.Color.RosyBrown;
            this.pnlRanking.Controls.Add(this.lblOwnRecord);
            this.pnlRanking.Controls.Add(this.label2);
            this.pnlRanking.Controls.Add(this.lblThird);
            this.pnlRanking.Controls.Add(this.lblSecond);
            this.pnlRanking.Controls.Add(this.lblFirst);
            this.pnlRanking.Controls.Add(this.label1);
            this.pnlRanking.Controls.Add(this.lblRanking);
            this.pnlRanking.Location = new System.Drawing.Point(335, 70);
            this.pnlRanking.Name = "pnlRanking";
            this.pnlRanking.Size = new System.Drawing.Size(324, 461);
            this.pnlRanking.TabIndex = 8;
            this.pnlRanking.Visible = false;
            // 
            // lblOwnRecord
            // 
            this.lblOwnRecord.AutoSize = true;
            this.lblOwnRecord.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOwnRecord.Location = new System.Drawing.Point(21, 419);
            this.lblOwnRecord.Name = "lblOwnRecord";
            this.lblOwnRecord.Size = new System.Drawing.Size(81, 14);
            this.lblOwnRecord.TabIndex = 13;
            this.lblOwnRecord.Text = "12. Pascal: 500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "Deine Platzierung:";
            // 
            // lblThird
            // 
            this.lblThird.AutoSize = true;
            this.lblThird.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThird.ForeColor = System.Drawing.Color.SandyBrown;
            this.lblThird.Location = new System.Drawing.Point(21, 97);
            this.lblThird.Name = "lblThird";
            this.lblThird.Size = new System.Drawing.Size(103, 16);
            this.lblThird.TabIndex = 11;
            this.lblThird.Text = "3. Herbert: 250";
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.ForeColor = System.Drawing.Color.Silver;
            this.lblSecond.Location = new System.Drawing.Point(21, 78);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(82, 16);
            this.lblSecond.TabIndex = 10;
            this.lblSecond.Text = "2. Test: 300";
            // 
            // lblFirst
            // 
            this.lblFirst.AutoSize = true;
            this.lblFirst.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirst.ForeColor = System.Drawing.Color.Yellow;
            this.lblFirst.Location = new System.Drawing.Point(21, 58);
            this.lblFirst.Name = "lblFirst";
            this.lblFirst.Size = new System.Drawing.Size(102, 18);
            this.lblFirst.TabIndex = 9;
            this.lblFirst.Text = "1. Pascal: 400";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblTime
            // 
            this.lblTime.AlignText = false;
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTime.BackColor = System.Drawing.Color.LightGray;
            this.lblTime.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(107, 299);
            this.lblTime.Name = "lblTime";
            this.lblTime.NewText = "3 Minuten 50 Sekunden";
            this.lblTime.RotateAngle = 270;
            this.lblTime.Size = new System.Drawing.Size(19, 188);
            this.lblTime.TabIndex = 5;
            // 
            // lblScore
            // 
            this.lblScore.AlignText = false;
            this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblScore.BackColor = System.Drawing.Color.LightGray;
            this.lblScore.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScore.Location = new System.Drawing.Point(107, 131);
            this.lblScore.Name = "lblScore";
            this.lblScore.NewText = "Pascal: 300";
            this.lblScore.RotateAngle = 270;
            this.lblScore.Size = new System.Drawing.Size(19, 95);
            this.lblScore.TabIndex = 4;
            // 
            // BounceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.ControlBox = false;
            this.Controls.Add(this.pnlRanking);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "BounceForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BounceForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BounceForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BounceForm_KeyUp);
            this.pnlRanking.ResumeLayout(false);
            this.pnlRanking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timerPaddle;
        internal System.Windows.Forms.Timer timerMain;
        internal System.Windows.Forms.Timer timerBalls;
        private System.Windows.Forms.Label lblDebug;
        internal System.Windows.Forms.Timer timerAddBall;
        private Main.RotatingLabel lblTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblRanking;
        private System.Windows.Forms.Panel pnlRanking;
        private System.Windows.Forms.Label lblThird;
        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Label lblFirst;
        private System.Windows.Forms.Label lblOwnRecord;
        private System.Windows.Forms.Label label2;
        private Main.RotatingLabel lblScore;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}