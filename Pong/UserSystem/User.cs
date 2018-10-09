using RetroTable.Main;
using RetroTable.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.UserSystem
{

    public class User
    {
        internal int Id { get; private set; }
        internal string Name { get; set; }
        internal float BallSpeed { get; set; }
        internal int PanelSize { get; set; }
        internal int TimeLimit { get; set; }
        internal int PlayTimePong { get; set; }
        internal int MadeGoalsPong { get; set; }
        internal int TakenGoalsPong { get; set; }
        internal int DefendTimesPong { get; set; }
        internal DateTime Created { get; }

        /// <summary> Creates a pseudo User, only used when no Database is connected</summary>
        internal User(string name)
        {
            if (Retrotable.Databasemode)
                throw new Exception("Im Datenbankmodus können keine Instanzen von User selber erstellt werden!");

            Id = Retrotable.Random.Next(1, 100000);
            Name = name;
            BallSpeed = 2f;
            PanelSize = 150;
            TimeLimit = 3;
            Created = DateTime.Now;
        }

        internal void Save()
        {
            if (!Retrotable.Databasemode) return;
            Database.User.UserSave(this);
        }

        public static bool operator ==(User u1, User u2)
        {
            if (ReferenceEquals(u1, null))
            {
                return ReferenceEquals(u2, null);
            }

            if (ReferenceEquals(u2, null)) return false;

            return u1.Id.Equals(u2.Id);
        }

        public static bool operator !=(User u1, User u2)
        {
            return !(u1 == u2);
        }
    }
}
