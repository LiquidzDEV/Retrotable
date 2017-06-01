using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace Pong.Source
{
    public class Arduino
    {
        private static SerialPort arduino;

        private byte[] data = new byte[3];

        public Arduino()
        {
            try
            {
                arduino = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
                arduino.DataReceived += arduino_DataReceived;
                arduino.Open();
                arduino.DiscardInBuffer();
            }
            catch (Exception)
            {
                Pong.ARDUINOMODE = false;
                MessageBox.Show("Es kann über W,S und Up,Down gespielt werden.\nMit Leertaste startet die Runde.", "Kein Arduino gefunden!");
            }
        }

        public void write(BoardConstants cmd)
        {
            if (Pong.ARDUINOMODE)
            	arduino.Write(new Byte[]{Convert.ToByte((int)cmd)} , 0, 1);
        }

        private void arduino_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (arduino.BytesToRead > 2)
                {
                    //0 = player1, 1= player2, 2= start
                    arduino.Read(data, 0, 3);
                    Pong.instance.mainForm.BeginInvoke(new EventHandler(handleData));
                }
            }
            catch (Exception)
            {

            }
        }

        private void handleData(object sender, EventArgs e)
        {
            if (data[2] == 1 && !Pong.instance.started)
            {
                write(BoardConstants.RED);
                Pong.instance.ball.Start();
                Pong.instance.started = true;
            }

            Pong.instance.player1.setRelativePanelPosition(data[0]);
            Pong.instance.player2.setRelativePanelPosition(data[1]);
        }

        public void close()
        {
            try
            {
                write(BoardConstants.DEFAULT);
                arduino.Close();
                arduino.Dispose();
            }
            catch (Exception) { }
        }
    }
}
