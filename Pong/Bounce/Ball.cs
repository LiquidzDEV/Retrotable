using RetroTable.Main;
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
        private int Id { get; }

        public Ball()
        {
            Id = Retrotable.Random.Next();
            Anchor = AnchorStyles.None;
            BackColor = System.Drawing.Color.Transparent;
            BackgroundImage = ballBlack;
            BackgroundImageLayout = ImageLayout.Center;
            Location = new System.Drawing.Point(512, 281);
            Margin = new Padding(4);
            Name = "pBall" + Id;
            Size = new System.Drawing.Size(20, 20);
            TabStop = false;
        }
    }
}
