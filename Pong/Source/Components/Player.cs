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

		public const int PANEL_SMALL = 50;
		public const int PANEL_NORMAL = 150;
		public const int PANEL_BIG = 200;
        
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
				pnl.Location = new Point(pnl.Location.X, Math.Max(World.upper, pnl.Location.Y - SPEED));
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
			Pong.Instance.MainForm.ResetRound();
			Pong.DebugMessage("Ein Punkt wurde vergeben.");
		}

		internal void setRelativePanelPosition(int percentage)
		{
			double position = (World.bottom - pnl.Size.Height - World.upper) / 100f * percentage;
			pnl.Location = new Point(pnl.Location.X, Math.Min(World.bottom - pnl.Size.Height, Convert.ToInt32(position) + World.upper));
		}
        
		public void setPanelHeight(int height)
		{
			pnl.Height = height;
			Pong.DebugMessage("Höhe des Balken wurde auf " + height + " gesetzt!");
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
