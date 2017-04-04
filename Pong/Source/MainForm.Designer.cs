/*
 * Pascal "Liquidz" H.
 * 10.02.2017 / 07:47
 * 
 * Description:
 */
namespace Pong.Source
{
    partial class MainForm
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        	this.pnlPlayer1 = new System.Windows.Forms.Panel();
        	this.pnlPlayer2 = new System.Windows.Forms.Panel();
        	this.timerPaddle = new System.Windows.Forms.Timer(this.components);
        	this.pBall = new System.Windows.Forms.PictureBox();
        	this.lblPlayer1 = new System.Windows.Forms.Label();
        	this.lblPlayer2 = new System.Windows.Forms.Label();
        	this.timerBall = new System.Windows.Forms.Timer(this.components);
        	this.timerIncreaseSpeed = new System.Windows.Forms.Timer(this.components);
        	this.label1 = new System.Windows.Forms.Label();
        	((System.ComponentModel.ISupportInitialize)(this.pBall)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// pnlPlayer1
        	// 
        	this.pnlPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Left;
        	this.pnlPlayer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        	this.pnlPlayer1.Location = new System.Drawing.Point(16, 233);
        	this.pnlPlayer1.Margin = new System.Windows.Forms.Padding(4);
        	this.pnlPlayer1.Name = "pnlPlayer1";
        	this.pnlPlayer1.Size = new System.Drawing.Size(20, 154);
        	this.pnlPlayer1.TabIndex = 0;
        	// 
        	// pnlPlayer2
        	// 
        	this.pnlPlayer2.Anchor = System.Windows.Forms.AnchorStyles.Right;
        	this.pnlPlayer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        	this.pnlPlayer2.Location = new System.Drawing.Point(992, 233);
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
        	this.pBall.Location = new System.Drawing.Point(512, 290);
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
        	this.lblPlayer1.Location = new System.Drawing.Point(384, 9);
        	this.lblPlayer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lblPlayer1.Name = "lblPlayer1";
        	this.lblPlayer1.Size = new System.Drawing.Size(63, 32);
        	this.lblPlayer1.TabIndex = 4;
        	this.lblPlayer1.Text = "0";
        	this.lblPlayer1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// lblPlayer2
        	// 
        	this.lblPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.lblPlayer2.BackColor = System.Drawing.Color.Transparent;
        	this.lblPlayer2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lblPlayer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
        	this.lblPlayer2.Location = new System.Drawing.Point(584, 9);
        	this.lblPlayer2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
        	this.lblPlayer2.Name = "lblPlayer2";
        	this.lblPlayer2.Size = new System.Drawing.Size(68, 32);
        	this.lblPlayer2.TabIndex = 5;
        	this.lblPlayer2.Text = "0";
        	this.lblPlayer2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// timerBall
        	// 
        	this.timerBall.Interval = 20;
        	this.timerBall.Tick += new System.EventHandler(this.timerBall_Tick);
        	// 
        	// timerIncreaseSpeed
        	// 
        	this.timerIncreaseSpeed.Interval = 10000;
        	this.timerIncreaseSpeed.Tick += new System.EventHandler(this.timerIncreaseSpeed_Tick);
        	// 
        	// label1
        	// 
        	this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.label1.BackColor = System.Drawing.Color.Transparent;
        	this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.ForeColor = System.Drawing.Color.Gray;
        	this.label1.Location = new System.Drawing.Point(467, 15);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(100, 23);
        	this.label1.TabIndex = 6;
        	this.label1.Text = "Score";
        	this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// MainForm
        	// 
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
        	this.BackColor = System.Drawing.Color.Black;
        	this.ClientSize = new System.Drawing.Size(1028, 545);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.pnlPlayer2);
        	this.Controls.Add(this.pnlPlayer1);
        	this.Controls.Add(this.lblPlayer2);
        	this.Controls.Add(this.lblPlayer1);
        	this.Controls.Add(this.pBall);
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.MinimumSize = new System.Drawing.Size(1044, 583);
        	this.Name = "MainForm";
        	this.Text = "Pong / Pascal Hobza, Jannik Herrmann";
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
        	this.SizeChanged += new System.EventHandler(this.MainFormSizeChanged);
        	this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
        	this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MainForm_KeyPress);
        	this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyUp);
        	((System.ComponentModel.ISupportInitialize)(this.pBall)).EndInit();
        	this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlPlayer1;
        private System.Windows.Forms.PictureBox pBall;
        private System.Windows.Forms.Panel pnlPlayer2;
        private System.Windows.Forms.Timer timerPaddle;
        private System.Windows.Forms.Label lblPlayer1;
        private System.Windows.Forms.Label lblPlayer2;
        private System.Windows.Forms.Timer timerBall;
        private System.Windows.Forms.Timer timerIncreaseSpeed;
        private System.Windows.Forms.Label label1;
    }
}
