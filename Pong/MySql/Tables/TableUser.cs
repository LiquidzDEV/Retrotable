using RetroTable.UserSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroTable.MySql.Tables
{
    public interface TableUser
    {
        List<User> UserGet();
        User UserHasName(string name);
        User UserCreate(string name, DateTime created);
        void UserSave(User user);
    }
}
