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
    public class DropdownService
    {
        DropDownEntryDao dropdownDao;

        public IList<DropDownEntry> GetAllDropDownEntries(string tableName)
        {
            dropdownDao = new DropDownEntryDao();
            return dropdownDao.GetAllDropDownEntrys(tableName);
        }

        public DropDownEntry SaveDropDownEntry(string tableName, DropDownEntry obj)
        {
            if (obj.Description.Length <= 0)
            {
                throw new ApplicationException();
            }

            dropdownDao = new DropDownEntryDao();
            return dropdownDao.SaveDropDownEntry(tableName, obj);
        }
    }
}
