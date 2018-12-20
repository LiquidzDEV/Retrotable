using RetroTable.Board;
using System;
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

        public static void AddData(PinMapping pin, int value)
        {
            if (Instance == null) return;

            Instance.Invoke((MethodInvoker)delegate
            {
                switch (pin)
                {
                    case PinMapping.Player1SliderSensLeft:
                        Instance.lblSenseLeft.Text = "Left 1: " + value;
                        break;
                    case PinMapping.Player1SliderSensRight:
                        Instance.lblSenseRight.Text = "Right 1: " + value;
                        break;
                    case PinMapping.Player2SliderSensLeft:
                        Instance.lblSenseLeft2.Text = "Left 2: " + value;
                        break;
                    case PinMapping.Player2SliderSensRight:
                        Instance.lblSenseRight2.Text = "Right 2: " + value;
                        break;
                    default:
                        var item = new ListViewItem(pin.ToString());
                        item.SubItems.Add(value.ToString());
                        item.SubItems.Add(DateTime.Now.ToShortTimeString());
                        Instance.lvwData.Items.Add(item);

                        if (Instance.lvwData.Items.Count > 100)
                        {
                            Instance.lvwData.Items.RemoveAt(0);
                        }
                        break;
                }
            });
        }
    }
}
