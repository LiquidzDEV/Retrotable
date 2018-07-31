using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroTable.Bounce
{
    internal partial class Ball : PictureBox
    {

        public Ball()
        {
            Anchor = AnchorStyles.None;
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImage = ballBlack;
            BackgroundImageLayout = ImageLayout.Center;
            Location = new System.Drawing.Point(512, 281);
            Margin = new Padding(4);
            Name = "pBall";
            Size = new System.Drawing.Size(20, 20);
            TabStop = false;
        }

        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
