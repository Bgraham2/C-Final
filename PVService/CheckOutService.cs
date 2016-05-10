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
    public class CheckOutService
    {
        CheckOutDao checkOutDao;

        public CheckOut SaveCheckOut(CheckOut obj)
        {
            checkOutDao = new CheckOutDao();
            return checkOutDao.SaveCheckOut(obj);
        }

    }
}
