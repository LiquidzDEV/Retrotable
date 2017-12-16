/*
 * Pascal "Liquidz" H.
 * 10.02.2017 / 07:09
 * 
 * Description:
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong.Source.Components
{
	/// <summary> Der Ball im Spielfeld. </summary>
	public class Ball
	{
		/// <summary> Der maximale horizontale speed des Balls. </summary>
		public const int MAX_SPEED = 35;
		/// <summary> Der speed den der Ball pro Event gewinnt. </summary>
		public const int SPEED_GAIN = 3;
		/// <summary> Geschwindigkeit die über das Menü eingestellt wird. </summary>
		private static int SPEED_LEVEL = 2;
		/// <summary> Der Speed am Rundenstart. </summary>
		public const int DEFAULT_SPEED = 10;

		private readonly PictureBox pBall;

		private int speedX;
		private int speedY;
                
		private int lastPlayerHit = 0;

		public Ball(PictureBox pBall)
		{
			this.pBall = pBall;
		}

		public void Start()
		{
            //Creates an instance of a generator for random numbers
		    var random = new Random();
            //Sets the y-speed of the ball randomly between -4 and 4
			speedY = random.Next(-4, 4);
            //Sets the x-speed on positive defaultspeed if random is lower than 5 and negative defaultspeed if random is greater or equal than 5
			speedX = random.Next(10) < 5 ? DEFAULT_SPEED : -DEFAULT_SPEED;
		}

		public void Move()
		{
			int bottom = World.bottom - pBall.Size.Height;

			//Bewege den Ball nach links/rechts, wenn er oben/unten anstößt halte seine Y Position
			pBall.Location = new Point(pBall.Location.X + speedX, Math.Max(World.upper, Math.Min(bottom, pBall.Location.Y + speedY)));

			//Wenn der Ball oben/unten anstößt wechsel die richtung Y
			if (pBall.Location.Y == bottom || pBall.Location.Y == World.upper)
			{
				speedY *= -1;
				Pong.DebugMessage("Ball ändert Richtung.");
			}

			//Wenn der Ball einen Spieler berührt wechsel die richtung X und bestimme einen neuen Flugwinkel
			int playerHit = isBallHittingPlayer();
			if (playerHit > 0 && lastPlayerHit != playerHit)
			{
				lastPlayerHit = playerHit;
				speedX *= -1;
				int random = new Random().Next(1, 12);
				speedY = speedY < 0 ? -random : random;
				Pong.DebugMessage("Spieler " + playerHit + " wurde vom Ball getroffen! Neuer Flugwinkel: " + random);
			}

			// Wenn der Ball am Spieler vorbei geht, verteil einen Punkt
			if (pBall.Location.X >= World.right - pBall.Size.Width)
			{
                ArduinoHelper.SetLeds(true, false);
				Pong.Instance.Player1.Score();
			}
			else if (pBall.Location.X <= 0)
			{
                ArduinoHelper.SetLeds(false, true);
				Pong.Instance.Player2.Score();
			}
		}
        
		/// <summary>
		/// Gibt die SpielerID zurück, mit welcher der Ball sich zurzeit überschneidet.
		/// </summary>
		/// <returns>Spieler-Id oder 0 wenn kein Spieler getroffen ist.</returns>
		private int isBallHittingPlayer()
		{
			if (Pong.Instance.Player1.hits(pBall))
				return 1;
			if (Pong.Instance.Player2.hits(pBall))
				return 2;
			return 0;
		}

		public void IncreaseSpeed()
		{
			if (speedX < MAX_SPEED * SPEED_LEVEL && speedX > -MAX_SPEED * SPEED_LEVEL)
			{
				speedX = speedX < 0 ? speedX - Ball.SPEED_GAIN * SPEED_LEVEL : speedX + Ball.SPEED_GAIN * SPEED_LEVEL;
				Pong.DebugMessage("BallSpeed erhöht auf " + speedX);
			}
		}
        
		public static void SetSpeedLevel(int level)
		{
			SPEED_LEVEL = level;
			Pong.DebugMessage("Ballspeedlevel wurde auf " + level + " gesetzt!");
		}

		public void Reset()
		{
			pBall.Location = new Point(((World.right - World.left) / 2) - (pBall.Size.Width / 2), ((World.bottom - World.upper) / 2) - (pBall.Size.Height / 2));
			lastPlayerHit = 0;
		}
	}
}
