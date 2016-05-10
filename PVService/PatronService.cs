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
    public class PatronService
    {
        PatronDao patronDao;

        public IList<Patron> GetPatrons(Patron obj)
        {
            patronDao = new PatronDao();
            return patronDao.GetPatrons(obj);
        }

        public Patron SavePatron(Patron obj)
        {

            string hashedPassword = string.Empty;
            string firstName = obj.FirstName;
            string lastName = obj.LastName;
            string username = obj.Username;
            string password = obj.Password;

            StringBuilder sb = new StringBuilder();

            if (obj.FirstName.Length <= 0)
            {
                sb.Append("First Name is required<br/>");
            }

            if (obj.LastName.Length <= 0)
            {
                sb.Append("Last Name is required<br/>");
            }

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

            if (password.Length < 30)
            {
                bool strongPassword = PVUtil.WebHelper.verifyPasswordStrength(password);
                hashedPassword = BCrypt.HashPassword(password, BCrypt.GenerateSalt(4));
            }
            else
            {
                hashedPassword = password;
            }

            obj.Password = hashedPassword;

            patronDao = new PatronDao();
            return patronDao.SavePatron(obj);
        }

        public Patron EditPatron(Patron obj)
        {

            string hashedPassword = string.Empty;
            string firstName = obj.FirstName;
            string lastName = obj.LastName;
            string username = obj.Username;
            string password = obj.Password;

            StringBuilder sb = new StringBuilder();

            if (obj.FirstName.Length <= 0)
            {
                sb.Append("First Name is required<br/>");
            }

            if (obj.LastName.Length <= 0)
            {
                sb.Append("Last Name is required<br/>");
            }

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

            if (password.Length < 30)
            {
                bool strongPassword = PVUtil.WebHelper.verifyPasswordStrength(password);
                hashedPassword = BCrypt.HashPassword(password, BCrypt.GenerateSalt(4));
            }
            else
            {
                hashedPassword = password;
            }

            obj.Password = hashedPassword;

            patronDao = new PatronDao();
            return patronDao.EditPatron(obj);
        }
    }
}
