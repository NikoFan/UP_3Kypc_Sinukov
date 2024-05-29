using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SinukovUP.Properties;

namespace SinukovUP
{
    internal class MemoryWork
    {

        // Запись ID пользователя в КЕШ
        public void setUserID(ulong ID)
        {
            Settings.Default["UserID"] = ID;
            Settings.Default.Save();
        }
        // Возврат ID пользователя
        public string getUserID() => Settings.Default["UserID"].ToString();

        // Запись роли пользователя
        public void setUserROLE(string Role)
        {
            Settings.Default["UserROLE"] = Role;
            Settings.Default.Save();
        }

        // Возврат роли пользователя
        public string getUserROLE() => Settings.Default["UserROLE"].ToString();

    }
}
