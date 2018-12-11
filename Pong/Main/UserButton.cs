using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RetroTable.Main
{
    internal class UserButton : Button
    {
        internal int GetUserId()
        {
            if (Int32.TryParse(Regex.Match(this.Name, @"\d+").Value, out int userId))
            {
                return userId;
            }
            return -1;
        }
    }
}
