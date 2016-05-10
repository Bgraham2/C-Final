using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

[assembly: log4net.Config.DOMConfigurator(ConfigFileExtension = "log4net", Watch = true)]

namespace PVUtil
{

    // a file named: PVUtil.dll.log4net, this must be placed in teh root of the calling app

    public sealed class PVLogger
    {

        private static readonly log4net.ILog pvLogger = LogManager.GetLogger("PVLogger");

        private PVLogger()
        {

        }

        public static log4net.ILog PVlog
        {

            get { return pvLogger; }

        }

        public static log4net.ILog TypedLogger(System.Type type)
        {

            return LogManager.GetLogger(type);

        }
    }
}
