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
    public class CheckedOutService
    {
        CheckedOutDao checkedOutDao;

        public IList<CheckedOut> GetCheckedOut(CheckedOut obj)
        {
            checkedOutDao = new CheckedOutDao();
            return checkedOutDao.GetCheckedOut(obj);
        }

    }
}
