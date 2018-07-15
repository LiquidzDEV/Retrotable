using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.UserSystem
{

    public class User
    {
        internal int id { get; private set; }
        internal string name { get; private set; }
        internal float BallSpeed { get; set; }
        internal int PanelSize { get; set; }

        internal void Save()
        {

        }

    }
}
