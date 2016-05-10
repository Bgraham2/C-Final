using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Security;

namespace PVUtil
{
    public class PVEncrypter
    {
        public static string EncryptString(string inputString)
        {

            return FormsAuthentication.HashPasswordForStoringInConfigFile(inputString, FormsAuthPasswordFormat.MD5.ToString());

        }
    }
}
