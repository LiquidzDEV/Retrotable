using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.Bounce
{
    public class Bounce
    {
        internal Ball Ball { get; }

        internal Player Player { get; }

        private BounceForm BounceForm;

        public Bounce()
        {
            BounceForm = new BounceForm(this);

            Player = new Player(1);
            BounceForm.Controls.Add(Player);

            Ball = new Ball();
            BounceForm.Controls.Add(Ball);
        }

        internal void Show()
        {
            BounceForm.Show();
        }

        internal void Hide()
        {
            BounceForm.Hide();
        }

        internal void Start()
        {

        }

        internal void Reset()
        {

        }
    }
}
