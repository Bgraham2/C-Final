using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using PVUtil;
using log4net;
using System.Configuration;
using PVDomain;

namespace PVData
{
    public class LibraryItemMapper : ABaseMapper
    {
        LibraryItem obj;

        public LibraryItemMapper(SqlDataReader reader)
            :base(reader)
        {

        }

        public override object DoMapping()
        {
            int index = 0;

            obj = new LibraryItem();

            obj.Id = MapLong(index++);
            obj.ItemTypeId = MapLong(index++);
            obj.PublisherId = MapLong(index++);
            obj.AuthorId = MapLong(index++);
            obj.Title = MapString(index++);
            obj.Isbn  = MapString(index++);

           

            return obj;
        }
    }
}
