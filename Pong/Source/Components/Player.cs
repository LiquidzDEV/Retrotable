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
		private const int Speed = 20;

		public const int PanelSmall = 50;
		public const int PanelNormal = 150;
		public const int PanelBig = 200;
        
		private readonly Panel _pnl;
		private readonly Label _lblScore;

		public bool PlayerUp;
		public bool PlayerDown;

		private int _score;

		public Player(Panel pnl, Label lblScore)
		{
			_pnl = pnl;
			_lblScore = lblScore;
		}

		public void Move()
		{
			if (PlayerUp)
			{
				_pnl.Location = new Point(_pnl.Location.X, Math.Max(World.Upper, _pnl.Location.Y - Speed));
			}
			else if (PlayerDown)
			{
				_pnl.Location = new Point(_pnl.Location.X, Math.Min(World.Bottom - _pnl.Size.Height, _pnl.Location.Y + Speed));
			} 
		}

		internal void Score()
		{
			_score++;
			_lblScore.Text = _score.ToString();
			Pong.Instance.MainForm.ResetRound();
			Pong.DebugMessage("Ein Punkt wurde vergeben.");
		}

		internal void SetRelativePanelPosition(int percentage)
		{
			double position = (World.Bottom - _pnl.Size.Height - World.Upper) / 100f * percentage;
			_pnl.Location = new Point(_pnl.Location.X, Math.Min(World.Bottom - _pnl.Size.Height, Convert.ToInt32(position) + World.Upper));
		}
        
		public void SetPanelHeight(int height)
		{
			_pnl.Height = height;
			Pong.DebugMessage("Höhe des Balken wurde auf " + height + " gesetzt!");
		}

		internal bool Hits(PictureBox ball)
		{
			return _pnl.Bounds.IntersectsWith(ball.Bounds);
		}

		internal void Reset()
		{
			_pnl.Location = new Point(_pnl.Location.X, ((World.Bottom - World.Upper) / 2) - (_pnl.Size.Height / 2));
		}
        
		public void Resize()
		{
			_pnl.Location = new Point(_pnl.Location.X, Math.Min(World.Bottom - _pnl.Size.Height, _pnl.Location.Y));
		}
	}
}
