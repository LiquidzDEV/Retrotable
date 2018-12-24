namespace RetroTable.Test
{
    partial class ArduinoDataTest
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
            this.lvwData = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSenseLeft = new System.Windows.Forms.Label();
            this.lblSenseRight = new System.Windows.Forms.Label();
            this.lblSenseLeft2 = new System.Windows.Forms.Label();
            this.lblSenseRight2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwData
            // 
            this.lvwData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwData.FullRowSelect = true;
            this.lvwData.GridLines = true;
            this.lvwData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwData.Location = new System.Drawing.Point(12, 55);
            this.lvwData.MultiSelect = false;
            this.lvwData.Name = "lvwData";
            this.lvwData.Size = new System.Drawing.Size(283, 216);
            this.lvwData.TabIndex = 0;
            this.lvwData.UseCompatibleStateImageBehavior = false;
            this.lvwData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Pin";
            this.columnHeader1.Width = 173;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 52;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Time";
            this.columnHeader3.Width = 52;
            // 
            // lblSenseLeft
            // 
            this.lblSenseLeft.AutoSize = true;
            this.lblSenseLeft.Location = new System.Drawing.Point(12, 9);
            this.lblSenseLeft.Name = "lblSenseLeft";
            this.lblSenseLeft.Size = new System.Drawing.Size(35, 13);
            this.lblSenseLeft.TabIndex = 1;
            this.lblSenseLeft.Text = "label1";
            // 
            // lblSenseRight
            // 
            this.lblSenseRight.AutoSize = true;
            this.lblSenseRight.Location = new System.Drawing.Point(152, 9);
            this.lblSenseRight.Name = "lblSenseRight";
            this.lblSenseRight.Size = new System.Drawing.Size(35, 13);
            this.lblSenseRight.TabIndex = 2;
            this.lblSenseRight.Text = "label2";
            // 
            // lblSenseLeft2
            // 
            this.lblSenseLeft2.AutoSize = true;
            this.lblSenseLeft2.Location = new System.Drawing.Point(12, 30);
            this.lblSenseLeft2.Name = "lblSenseLeft2";
            this.lblSenseLeft2.Size = new System.Drawing.Size(35, 13);
            this.lblSenseLeft2.TabIndex = 3;
            this.lblSenseLeft2.Text = "label3";
            // 
            // lblSenseRight2
            // 
            this.lblSenseRight2.AutoSize = true;
            this.lblSenseRight2.Location = new System.Drawing.Point(152, 30);
            this.lblSenseRight2.Name = "lblSenseRight2";
            this.lblSenseRight2.Size = new System.Drawing.Size(35, 13);
            this.lblSenseRight2.TabIndex = 4;
            this.lblSenseRight2.Text = "label4";
            // 
            // ArduinoDataTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 281);
            this.Controls.Add(this.lblSenseRight2);
            this.Controls.Add(this.lblSenseLeft2);
            this.Controls.Add(this.lblSenseRight);
            this.Controls.Add(this.lblSenseLeft);
            this.Controls.Add(this.lvwData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MinimumSize = new System.Drawing.Size(323, 278);
            this.Name = "ArduinoDataTest";
            this.Text = "ArduinoDataTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label lblSenseLeft;
        private System.Windows.Forms.Label lblSenseRight;
        private System.Windows.Forms.Label lblSenseLeft2;
        private System.Windows.Forms.Label lblSenseRight2;
    }
}