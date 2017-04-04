﻿/*
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
        public const int MAX_SPEED = 40;
        /// <summary> Der speed den der Ball pro Event gewinnt. </summary>
		public const int SPEED_GAIN = 4;
		/// <summary> Der Speed am Rundenstart. </summary>
		public const int DEFAULT_SPEED = 12;

        private readonly PictureBox pBall;

        private int speedX;
        private int speedY;
                
        //TODO Wenn er auf einen Spieler trifft soll er nur einmal die richtung wechseln damit er nicht im Spieler buggt
		private int lastPlayerHit = 0;

        public Ball(PictureBox pBall)
        {
            this.pBall = pBall;
        }

        public void Start()
        {
            int random = new Random().Next(-4, 4);
            speedY = random;
            random = new Random().Next(10);
            speedX = random < 5 ? Ball.DEFAULT_SPEED : -Ball.DEFAULT_SPEED;
        }

        public void Move()
        {
            int bottom = World.bottom - pBall.Size.Height;

            //Bewege den Ball nach links/rechts, wenn er oben/unten anstößt halte seine Y Position
            pBall.Location = new Point(pBall.Location.X + speedX, Math.Max(0, Math.Min(bottom, pBall.Location.Y + speedY)));

            //Wenn der Ball oben/unten anstößt wechsel die richtung Y
            if (pBall.Location.Y == bottom || pBall.Location.Y == 0)
            {
                speedY *= -1;
				Pong.debugMessage("Ball ändert Richtung.");
            }

			//Wenn der Ball einen Spieler berührt wechsel die richtung X und bestimme einen neuen Flugwinkel
			int playerHit = isBallHittingPlayer();
            if (playerHit > 0 && lastPlayerHit != playerHit)
            {
				lastPlayerHit = playerHit;
                speedX *= -1;
                int random = new Random().Next(1, 12);
                speedY = speedY < 0 ? -random : random;
				Pong.debugMessage("Spieler " + playerHit + " wurde vom Ball getroffen! Neuer Flugwinkel: "+ random);
            }

            // Wenn der Ball am Spieler vorbei geht, verteil einen Punkt
            if (pBall.Location.X >= World.right - pBall.Size.Width)
            {
                Pong.instance.arduino.write(BoardConstants.PLAYER1);
                Pong.instance.player1.Score();
            }
            else if (pBall.Location.X <= 0)
            {
                Pong.instance.arduino.write(BoardConstants.PLAYER2);
                Pong.instance.player2.Score();
            }
        }
        
        /// <summary>
        /// Gibt die SpielerID zurück, mit welcher der Ball sich zurzeit überschneidet.
        /// </summary>
        /// <returns>Spieler-Id oder 0 wenn kein Spieler getroffen ist.</returns>
        private int isBallHittingPlayer(){
        	if(Pong.instance.player1.hits(pBall))
        		return 1;
			if(Pong.instance.player2.hits(pBall))
				return 2;
			return 0;
        }

        public void increaseSpeed()
        {
            if (speedX < MAX_SPEED && speedX > -MAX_SPEED)
            {
                speedX = speedX < 0 ? speedX - Ball.SPEED_GAIN : speedX + Ball.SPEED_GAIN;
                Pong.debugMessage("BallSpeed erhöht auf " + speedX);
            }
        }

        public void reset()
        {
            pBall.Location = new Point(((World.right - World.left) / 2) - (pBall.Size.Width / 2), ((World.bottom - World.upper) / 2) - (pBall.Size.Height / 2));
            lastPlayerHit = 0;
        }
    }
}