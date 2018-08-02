using RetroTable.Main;
using RetroTable.UserSystem;
using System;
using System.Windows.Forms;

namespace RetroTable.Bounce
{
    public class Player : Panel
    {
        private const int MoveTempo = 20;

        private int Index { get; }

        internal int Score { get; private set; }

        private bool MoveUp;
        private bool MoveDown;

        internal Player(Form parent, int index)
        {
            Index = index;

            Anchor = AnchorStyles.Left;
            BackColor = System.Drawing.Color.FromArgb(192, 0, 0);
            Margin = new Padding(4);
            Name = "pnlPlayer" + Index;
            Size = new System.Drawing.Size(20, 154);

            Retrotable.onValueChanged += Retrotable_onValueChanged;

            parent.Controls.Add(this);
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

        internal void SetScore(int score)
        {
            Score = score;
            var lblScore = Parent.Controls.Find("lblScore", true);
            if (lblScore[0] is RotatingLabel rotLabel)
            {
                rotLabel.NewText = UserManager.Player1.Name + ": " + Score;
            }
            else
            {
                lblScore[0].Text = UserManager.Player1.Name + ": " + Score;
            }

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
