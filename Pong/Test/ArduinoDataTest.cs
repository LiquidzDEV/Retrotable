using RetroTable.Board;
using RetroTable.Main;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RetroTable.Test
{
    public partial class ArduinoDataTest : Form
    {
        private static ArduinoDataTest Instance;

        public ArduinoDataTest()
        {
            InitializeComponent();
            Instance = this;
        }

        public static void AddDigitalData(PinMapping pin, int value)
        {
            if (Instance == null) return;

            Instance.Invoke((MethodInvoker)delegate
            {
                var item = new ListViewItem(pin.ToString());
                item.SubItems.Add(value.ToString());
                item.SubItems.Add(DateTime.Now.ToShortTimeString());
                Instance.lvwData.Items.Add(item);

                if (Instance.lvwData.Items.Count > 100)
                {
                    Instance.lvwData.Items.RemoveAt(0);
                }
            });
        }

        public static void AddAnalogData(PinMapping pin, int value)
        {
            if (Instance == null) return;

            Instance.Invoke((MethodInvoker)delegate
            {
                switch (pin)
                {
                    case PinMapping.Player1SliderSensLeft:
                        if (Retrotable.SliderSample[0].Count == 0) break;
                        Instance.lblSenseLeft.Text = "Left 1: " + value + "\nAverage: "+ Retrotable.SliderSample[0].Average() + "\nMin: " + Retrotable.SliderSample[0].Min() + "\nMax: "+ Retrotable.SliderSample[0].Max();
                        break;
                    case PinMapping.Player1SliderSensRight:
                        if (Retrotable.SliderSample[1].Count == 0) break;
                        Instance.lblSenseRight.Text = "Right 1: " + value + "\nAverage: " + Retrotable.SliderSample[1].Average() + "\nMin: " + Retrotable.SliderSample[1].Min() + "\nMax: " + Retrotable.SliderSample[1].Max();
                        break;
                    case PinMapping.Player2SliderSensLeft:
                        if (Retrotable.SliderSample[2].Count == 0) break;
                        Instance.lblSenseLeft2.Text = "Left 2: " + value + "\nAverage: " + Retrotable.SliderSample[2].Average() + "\nMin: " + Retrotable.SliderSample[2].Min() + "\nMax: " + Retrotable.SliderSample[2].Max();
                        break;
                    case PinMapping.Player2SliderSensRight:
                        if (Retrotable.SliderSample[3].Count == 0) break;
                        Instance.lblSenseRight2.Text = "Right 2: " + value + "\nAverage: " + Retrotable.SliderSample[3].Average() + "\nMin: " + Retrotable.SliderSample[3].Min() + "\nMax: " + Retrotable.SliderSample[3].Max();                  
                        break;
                }
            });
        }
    }
}
