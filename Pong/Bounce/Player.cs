using RetroTable.Main;
using System;
using System.Windows.Forms;

namespace RetroTable.Bounce
{
    public class Player : Panel
    {
        private const int MoveTempo = 10;

        private int Index { get; }

        private bool MoveUp;
        private bool MoveDown;

        public Player(int index)
        {
            Index = index;

            Anchor = AnchorStyles.Left;
            BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            Margin = new Padding(4);
            Name = "pnlPlayer" + Index;
            Size = new System.Drawing.Size(20, 154);

            Retrotable.onValueChanged += Retrotable_onValueChanged;
        }

        private void Retrotable_onValueChanged(Board.PinMapping button, int newValue)
        {
            Location = new System.Drawing.Point(Location.X, (int)(Parent.Bounds.Height - Bounds.Height * (newValue / 100f)));
        }

        internal void SetMoveSet(bool up, bool keyDown)
        {
            if (up)
                MoveUp = keyDown;
            else
                MoveDown = keyDown;
        }

        internal new void Move()
        {
            if (MoveUp)
                Location = new System.Drawing.Point(Location.X, Math.Max(0, Location.Y - MoveTempo));
            else if (MoveDown)
                Location = new System.Drawing.Point(Location.X, Math.Min(Parent.Height - Bounds.Height, Location.Y + MoveTempo));
        }
    }
}
