using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVData;
using PVDomain;
using PVUtil;

namespace PVService
{
    public class LogInService
    {
        LogInDao loginDao;

        public IList<LogIn> GetLogIn(LogIn obj)
        {
            string username = obj.Username;
            string password = obj.Password;

            StringBuilder sb = new StringBuilder();

            if (obj.Username.Length <= 0)
            {
                sb.Append("Username is required<br/>");
            }

            if (obj.Password.Length <= 0)
            {
                sb.Append("A Password is required<br/>");
            }

            if (sb.Length > 0)
            {
                throw new ApplicationException(sb.ToString());
            }

          
            loginDao = new LogInDao();
            return loginDao.GetLogIn(obj);
        }

    }
}
