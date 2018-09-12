namespace RetroTable.UserSystem
{
    partial class UserMenuForm
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.trbBallSpeed = new System.Windows.Forms.TrackBar();
            this.trbPanelSize = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblBallSpeed = new System.Windows.Forms.Label();
            this.lblPanelSize = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblTimeLimit = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trbTimeLimit = new System.Windows.Forms.TrackBar();
            this.lblPlayTime = new System.Windows.Forms.Label();
            this.lblMadeGoals = new System.Windows.Forms.Label();
            this.lblDefended = new System.Windows.Forms.Label();
            this.lblTakenGoals = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbBallSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPanelSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTimeLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(174, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(164, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // trbBallSpeed
            // 
            this.trbBallSpeed.LargeChange = 50;
            this.trbBallSpeed.Location = new System.Drawing.Point(121, 46);
            this.trbBallSpeed.Maximum = 500;
            this.trbBallSpeed.Minimum = 100;
            this.trbBallSpeed.Name = "trbBallSpeed";
            this.trbBallSpeed.Size = new System.Drawing.Size(267, 45);
            this.trbBallSpeed.SmallChange = 5;
            this.trbBallSpeed.TabIndex = 1;
            this.trbBallSpeed.TickFrequency = 25;
            this.trbBallSpeed.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbBallSpeed.Value = 200;
            this.trbBallSpeed.ValueChanged += new System.EventHandler(this.trbBallSpeed_ValueChanged);
            // 
            // trbPanelSize
            // 
            this.trbPanelSize.LargeChange = 20;
            this.trbPanelSize.Location = new System.Drawing.Point(122, 97);
            this.trbPanelSize.Maximum = 500;
            this.trbPanelSize.Minimum = 30;
            this.trbPanelSize.Name = "trbPanelSize";
            this.trbPanelSize.Size = new System.Drawing.Size(266, 45);
            this.trbPanelSize.TabIndex = 2;
            this.trbPanelSize.TickFrequency = 20;
            this.trbPanelSize.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbPanelSize.Value = 150;
            this.trbPanelSize.ValueChanged += new System.EventHandler(this.trbPanelSize_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Benutzername:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ballgeschwindigkeit:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Balkengröße:";
            // 
            // lblBallSpeed
            // 
            this.lblBallSpeed.AutoSize = true;
            this.lblBallSpeed.Location = new System.Drawing.Point(12, 59);
            this.lblBallSpeed.Name = "lblBallSpeed";
            this.lblBallSpeed.Size = new System.Drawing.Size(22, 13);
            this.lblBallSpeed.TabIndex = 6;
            this.lblBallSpeed.Text = "2.0";
            // 
            // lblPanelSize
            // 
            this.lblPanelSize.AutoSize = true;
            this.lblPanelSize.Location = new System.Drawing.Point(12, 110);
            this.lblPanelSize.Name = "lblPanelSize";
            this.lblPanelSize.Size = new System.Drawing.Size(36, 13);
            this.lblPanelSize.TabIndex = 7;
            this.lblPanelSize.Text = "150px";
            // 
            // lblInfo
            // 
            this.lblInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblInfo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblInfo.Location = new System.Drawing.Point(12, 284);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(376, 17);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Location = new System.Drawing.Point(12, 304);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(180, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(208, 304);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(180, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblTimeLimit
            // 
            this.lblTimeLimit.AutoSize = true;
            this.lblTimeLimit.Location = new System.Drawing.Point(12, 161);
            this.lblTimeLimit.Name = "lblTimeLimit";
            this.lblTimeLimit.Size = new System.Drawing.Size(54, 13);
            this.lblTimeLimit.TabIndex = 13;
            this.lblTimeLimit.Text = "3 Minuten";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Zeitlimit:";
            // 
            // trbTimeLimit
            // 
            this.trbTimeLimit.LargeChange = 2;
            this.trbTimeLimit.Location = new System.Drawing.Point(122, 148);
            this.trbTimeLimit.Maximum = 15;
            this.trbTimeLimit.Minimum = 1;
            this.trbTimeLimit.Name = "trbTimeLimit";
            this.trbTimeLimit.Size = new System.Drawing.Size(266, 45);
            this.trbTimeLimit.TabIndex = 11;
            this.trbTimeLimit.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trbTimeLimit.Value = 3;
            this.trbTimeLimit.ValueChanged += new System.EventHandler(this.trbTimeLimit_ValueChanged);
            // 
            // lblPlayTime
            // 
            this.lblPlayTime.AutoSize = true;
            this.lblPlayTime.Location = new System.Drawing.Point(12, 266);
            this.lblPlayTime.Name = "lblPlayTime";
            this.lblPlayTime.Size = new System.Drawing.Size(194, 13);
            this.lblPlayTime.TabIndex = 14;
            this.lblPlayTime.Text = "Spielzeit Pong: 3 Minuten 10 Sekunden";
            // 
            // lblMadeGoals
            // 
            this.lblMadeGoals.AutoSize = true;
            this.lblMadeGoals.Location = new System.Drawing.Point(12, 246);
            this.lblMadeGoals.Name = "lblMadeGoals";
            this.lblMadeGoals.Size = new System.Drawing.Size(84, 13);
            this.lblMadeGoals.TabIndex = 15;
            this.lblMadeGoals.Text = "Erzielte Tore: 10";
            // 
            // lblDefended
            // 
            this.lblDefended.AutoSize = true;
            this.lblDefended.Location = new System.Drawing.Point(12, 230);
            this.lblDefended.Name = "lblDefended";
            this.lblDefended.Size = new System.Drawing.Size(114, 13);
            this.lblDefended.TabIndex = 16;
            this.lblDefended.Text = "Abgewehrte Bälle: 100";
            // 
            // lblTakenGoals
            // 
            this.lblTakenGoals.AutoSize = true;
            this.lblTakenGoals.Location = new System.Drawing.Point(171, 246);
            this.lblTakenGoals.Name = "lblTakenGoals";
            this.lblTakenGoals.Size = new System.Drawing.Size(87, 13);
            this.lblTakenGoals.TabIndex = 17;
            this.lblTakenGoals.Text = "Kassierte Tore: 5";
            // 
            // UserMenuForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(400, 339);
            this.Controls.Add(this.lblTakenGoals);
            this.Controls.Add(this.lblDefended);
            this.Controls.Add(this.lblMadeGoals);
            this.Controls.Add(this.lblPlayTime);
            this.Controls.Add(this.lblTimeLimit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.trbTimeLimit);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.lblPanelSize);
            this.Controls.Add(this.lblBallSpeed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trbPanelSize);
            this.Controls.Add(this.trbBallSpeed);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserMenuForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UserMenuForm";
            ((System.ComponentModel.ISupportInitialize)(this.trbBallSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbPanelSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbTimeLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblBallSpeed;
        private System.Windows.Forms.Label lblPanelSize;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TrackBar trbBallSpeed;
        private System.Windows.Forms.TrackBar trbPanelSize;
        private System.Windows.Forms.Label lblTimeLimit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trbTimeLimit;
        private System.Windows.Forms.Label lblPlayTime;
        private System.Windows.Forms.Label lblMadeGoals;
        private System.Windows.Forms.Label lblDefended;
        private System.Windows.Forms.Label lblTakenGoals;
    }
}