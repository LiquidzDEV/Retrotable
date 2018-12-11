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

        public static void AddData(int pin, int value)
        {
            if (Instance == null) return;

            var item = new ListViewItem(pin.ToString());
            item.SubItems.Add(value.ToString());
            item.SubItems.Add(DateTime.Now.ToShortTimeString());
            Instance.lvwData.Items.Add(item);

            if(Instance.lvwData.Items.Count > 100)
            {
                Instance.lvwData.Items.RemoveAt(0);
            }
        }
    }
}
