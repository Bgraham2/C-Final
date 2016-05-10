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
    public class OverDueService
    {
        OverDueDao overDueDao;

        public IList<OverDue> GetOverDue(OverDue obj)
        {
            overDueDao = new OverDueDao();
            return overDueDao.GetOverDue(obj);
        }

    }
}
