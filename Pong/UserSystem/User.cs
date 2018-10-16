using RetroTable.Main;
using RetroTable.MySql;
using System;

namespace RetroTable.UserSystem
{

    public class User
    {
        internal int User_Id { get; private set; }
        internal string Name { get; set; }
        internal float Ball_Speed { get; set; }
        internal int Panel_Size { get; set; }
        internal int Time_Limit { get; set; }
        internal int PlayTime_Pong { get; set; }
        internal int MadeGoals_Pong { get; set; }
        internal int TakenGoals_Pong { get; set; }
        internal int DefendTimes_Pong { get; set; }
        internal DateTime Created { get; private set; }

        public User()
        {

        }

        /// <summary> Creates a pseudo User, only used when no Database is connected</summary>
        internal User(string name)
        {
            if (Retrotable.Databasemode)
                throw new Exception("Im Datenbankmodus können keine Instanzen von User selber erstellt werden!");

            User_Id = Retrotable.Random.Next(1, 100000);
            Name = name;
            Ball_Speed = 2f;
            Panel_Size = 150;
            Time_Limit = 3;
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

            return u1.User_Id.Equals(u2.User_Id);
        }

        public static bool operator !=(User u1, User u2)
        {
            return !(u1 == u2);
        }
    }
}
