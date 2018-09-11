using RetroTable.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.MySql.Tables
{
    public interface TableGame
    {
        void UpdateGameData(LiveGameData gameData);
    }
}
