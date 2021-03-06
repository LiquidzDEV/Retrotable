﻿//<C#-Pong>
//Copyright(C) 2017-2018  Pascal H., Jannik H., Marc W., Yannic W.

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//GNU General Public License for more details.

//You should have received a copy of the GNU General Public License
//along with this program.If not, see<http://www.gnu.org/licenses/>.

using System;
using System.Windows.Forms;

namespace RetroTable.Main
{
    internal static class Program
    {
        /// <summary>
        /// The Main method of the Application, also named as the Entrypoint.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           
            Retrotable.Instance.Initialize();
        }
    }
}
