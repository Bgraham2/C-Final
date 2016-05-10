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
    public class LibraryItemService
    {
        LibraryItemDao libraryItemDao;

        public IList<LibraryItem> GetLibraryItem(LibraryItem obj)
        {
            libraryItemDao = new LibraryItemDao();
            return libraryItemDao.GetLibraryItem(obj);
        }

        public LibraryItem SaveLibraryItem(LibraryItem obj)
        {

            StringBuilder sb = new StringBuilder();

            if (obj.Title.Length <= 0)
            {
                sb.Append("Title is required<br/>");
            }

            if (obj.Isbn.Length <= 0)
            {
                sb.Append("An isbn is required<br/>");
            }

            if (sb.Length > 0)
            {
                throw new ApplicationException(sb.ToString());
            }
            libraryItemDao = new LibraryItemDao();
            return libraryItemDao.SaveLibraryItem(obj);
        }
    }
}
