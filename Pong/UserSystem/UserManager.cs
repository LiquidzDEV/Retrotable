using RetroTable.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.UserSystem
{
    internal class UserManager
    {
        private List<User> Users = new List<User>();

        public int Player1Id { get; private set; }
        public int Player2Id { get; private set; }

        internal UserManager()
        {

        }

        internal User CreateUser(string name)
        {
            if (Database.User.UserHasName(name) != null) return null;
            return Database.User.UserCreate(name);
        }

        private void UpdateUsers()
        {
            Users = new List<User>(); //TODO Database.User.UserGet();

            if (Player1Id > 0)
            {
                if (Users.Find(x => x.id == Player1Id) == null)
                    Player1Id = 0;
            }

            if (Player2Id > 0)
            {
                if (Users.Find(x => x.id == Player2Id) == null)
                    Player2Id = 0;
            }
        }

        internal List<User> GetUsers()
        {
            UpdateUsers();
            return Users.ToList();
        }
    }
}
