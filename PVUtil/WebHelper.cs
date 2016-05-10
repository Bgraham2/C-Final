using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PVUtil
{
    public class WebHelper
    {
        public static bool verifyPasswordStrength(string enteredPassword)
        {
            bool strongPassword = true;
            StringBuilder sb = new StringBuilder();

            enteredPassword = enteredPassword.Trim();

            if (enteredPassword.Length < 8)
            {
                strongPassword = false;
                sb.Append("Password must be at least 8 characters long<br/>");
                
            }

            if (!Regex.IsMatch(enteredPassword, "[0-9]"))
            {
                strongPassword = false;
                sb.Append("Password must have at least one digit<br/>");
                
            }

            if (!Regex.IsMatch(enteredPassword, "[a-z]"))
            {
                strongPassword = false;
                sb.Append("Password must have at least one lower case character<br/>");

            }

            if (!Regex.IsMatch(enteredPassword, "[A-Z]"))
            {
                strongPassword = false;
                sb.Append("Password must have at least one upper case character<br/>");

            }

            if (!Regex.IsMatch(enteredPassword, "[~|!|@|#|$|^|&|;]"))
            {
                strongPassword = false;
                sb.Append("Password must have at least one special character<br/>");

            }

            if (Regex.IsMatch(enteredPassword, " "))
            {
                strongPassword = false;
                sb.Append("Password must not contain spaces");

            }

            if (sb.Length > 0)
            {
                throw new ApplicationException(sb.ToString());
            }

            return strongPassword;
        }
    }
}
