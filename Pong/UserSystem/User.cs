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

        //TODO
        public User(string name)
        {
            Id = new Random().Next(1, 100000);
            Name = name;
            BallSpeed = 2f;
            PanelSize = 150;
        }

        internal void Save()
        {
            //TODO Database.Users.UserSave();
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
