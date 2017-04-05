/*
 * Pascal "Liquidz" H.
 * 10.02.2017 / 07:47
 * 
 * Description:
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Pong.Source.Components;

namespace Pong.Source
{
	/// <summary>
	/// Description of GameForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private Pong main;

		public MainForm()
		{
			this.main = Pong.instance;
			DoubleBuffered = true;
			InitializeComponent();
			World.setBounds(ClientSize.Height, ClientSize.Width);
			main.player1 = new Player(pnlPlayer1, lblPlayer1);
			main.player2 = new Player(pnlPlayer2, lblPlayer2);
			main.ball = new Ball(pBall);
            tsBalkenNormal.Checked = true;
            tsBallNormal.Checked = true;
			resetRound();
			timerPaddle.Start();
			timerBall.Start();
		}

		#region Bewegen der Balken
        
		void MainFormKeyDown(object sender, KeyEventArgs e)
		{
			setMovingState(e.KeyCode, true);
		}

		void MainFormKeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			setMovingState(e.KeyCode, false);
		}

		void setMovingState(Keys keycode, bool isKeyDown)
		{
			if (!Pong.ARDUINOMODE)
			{
				switch (keycode)
				{
					case Keys.W:
						main.player1.playerUp = isKeyDown;
						break;
					case Keys.S:
						main.player1.playerDown = isKeyDown;
						break;

					case Keys.Up:
						main.player2.playerUp = isKeyDown;
						break;
					case Keys.Down:
						main.player2.playerDown = isKeyDown;
						break;
				}
			}
		}
        
		void timerPaddle_Tick(object sender, EventArgs e)
		{
			main.player1.Move();
			main.player2.Move();
		}
		
		#endregion
		
		#region Ball
        
		private void timerBall_Tick(object sender, EventArgs e)
		{
			if (main.started)
				main.ball.Move();
		}

		private void timerIncreaseSpeed_Tick(object sender, EventArgs e)
		{
			main.ball.increaseSpeed();
		}
        
		#endregion
		
		void MainForm_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar.Equals(' ') && !main.started && !Pong.ARDUINOMODE)
			{
				main.ball.Start();
				timerIncreaseSpeed.Start();
				main.started = true;
			}
		}
        
		void MainFormSizeChanged(object sender, EventArgs e)
		{
			World.setBounds(ClientSize.Height, ClientSize.Width);
			main.player1.resize();
			main.player2.resize();
			Pong.debugMessage("Auflösung verändert. (" + ClientSize.Height + "/" + ClientSize.Width + ")");
		}

		public void resetRound()
		{
			main.started = false;
			timerIncreaseSpeed.Stop();
			main.player1.reset();
			main.player2.reset();
			main.ball.reset();
			Pong.debugMessage("Spiel wurde zurückgesetzt.");
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			Pong.instance.arduino.close();
		}

        #region MenuStrip

        void ToolStripCheckOnlyOne(object sender, EventArgs e)
		{
            if (sender is ToolStripMenuItem currentItem)
            {
                ((ToolStripMenuItem)currentItem.OwnerItem).DropDownItems.OfType<ToolStripMenuItem>().ToList()
                    .ForEach(item =>
                    {
                        item.Checked = false;
                    });

                currentItem.Checked = true;
            }
        }
		
		void ToolStrip_CheckedChanged(object sender, EventArgs e)
		{
			if (sender is ToolStripMenuItem currentItem)
			{	
				if(currentItem.Equals(tsBalkenSchmal)){
					main.player1.setPanelHeight(Player.PANEL_SMALL);
					main.player2.setPanelHeight(Player.PANEL_SMALL);
				}
				else if(currentItem.Equals(tsBalkenNormal)){
					main.player1.setPanelHeight(Player.PANEL_NORMAL);
					main.player2.setPanelHeight(Player.PANEL_NORMAL);
				}
				else if(currentItem.Equals(tsBalkenBreit)){
					main.player1.setPanelHeight(Player.PANEL_BIG);
					main.player2.setPanelHeight(Player.PANEL_BIG);
				}
                else if (currentItem.Equals(tsBallSlow))
                {
                    Ball.SPEED_LEVEL = 1;
                }
                else if (currentItem.Equals(tsBallNormal))
                {
                    Ball.SPEED_LEVEL = 2;
                }
                else if (currentItem.Equals(tsBallFast))
                {
                    Ball.SPEED_LEVEL = 3;
                }
            }
		}

        #endregion
	}
}
