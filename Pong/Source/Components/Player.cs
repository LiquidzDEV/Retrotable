/*
 * Pascal "Liquidz" H.
 * 10.02.2017 / 06:59
 * 
 * Description:
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong.Source.Components
{
    /// <summary>
    /// Description of Player.
    /// </summary>
    public class Player
    {
        public const int SPEED = 20;

        private readonly Panel pnl;
        private readonly Label lblScore;

        public bool playerUp;
        public bool playerDown;

        public int score;

        public Player(Panel pnl, Label lblScore)
        {
            this.pnl = pnl;
            this.lblScore = lblScore;
        }

        public void Move()
        {
            if (playerUp)
            {
                pnl.Location = new Point(pnl.Location.X, Math.Max(0, pnl.Location.Y - SPEED));
            }
            else if (playerDown)
            {
                pnl.Location = new Point(pnl.Location.X, Math.Min(World.bottom - pnl.Size.Height, pnl.Location.Y + SPEED));
            } 
        }

        internal void Score()
        {
            score++;
            lblScore.Text = score.ToString();
            Pong.instance.mainForm.resetRound();
			Pong.debugMessage("Ein Punkt wurde vergeben.");
        }

        internal void setRelativePanelPosition(int percentage)
        {
            double position = (World.bottom - pnl.Size.Height) / 100f * percentage;
            pnl.Location = new Point(pnl.Location.X, Math.Min(World.bottom - pnl.Size.Height, Convert.ToInt32(position)));
        }

        internal bool hits(PictureBox ball)
        {
            return pnl.Bounds.IntersectsWith(ball.Bounds);
        }

        internal void reset()
        {
            pnl.Location = new Point(pnl.Location.X, ((World.bottom - World.upper) / 2) - (pnl.Size.Height / 2));
        }
        
        public void resize()
        {
        	pnl.Location = new Point(pnl.Location.X, Math.Min(World.bottom - pnl.Size.Height, pnl.Location.Y));
        }
    }
}
