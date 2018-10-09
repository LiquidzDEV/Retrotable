using RetroTable.Main;
using RetroTable.MySql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.UserSystem
{
    internal static class UserManager
    {
        private static List<User> Users = new List<User>();

        public static User Player1 { get; set; }
        public static User Player2 { get; set; }

        internal static User CreateUser(string name)
        {
            if (Retrotable.Databasemode)
            {
                if (Database.User.UserHasName(name) != null) return null;

                var user = Database.User.UserCreate(name, DateTime.Now);

                System.Diagnostics.Debug.WriteLine("User " + user.Id + " " + user.Name + " erstellt");
                return user;
            }
            else
            {
                if (Users.Find(x => x.Name.ToLower() == name.ToLower()) != null) return null;

                var user = new User(name);

                Users.Add(user);
                System.Diagnostics.Debug.WriteLine("User " + user.Id + " " + user.Name + " LOKAL erstellt");
                return user;
            }
        }

        private static void UpdateUsers()
        {
            if (Retrotable.Databasemode)
                Users = Database.User.UserGet();

            if (Player1 != null && !Users.Contains(Player1))
            {
                Player1 = null;
            }

            if (Player2 != null && !Users.Contains(Player2))
            {
                Player2 = null;
            }
        }

        internal static List<User> GetUsers()
        {
            UpdateUsers();
            return Users.ToList();
        }

        internal static string GetName(int id)
        {
            UpdateUsers();

            var user = Users.Find(x => x.Id == id);

            if (user == null) return "Ungültiger Benutzer";

            return user.Name;
        }
    }
}
