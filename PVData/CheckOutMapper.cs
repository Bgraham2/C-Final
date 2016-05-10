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
    public class CheckOutMapper : ABaseMapper
    {
        CheckOut obj;

        public CheckOutMapper(SqlDataReader reader)
            :base(reader)
        {

        }

        public override object DoMapping()
        {
            int index = 0;

            obj = new CheckOut();

            obj.Id = MapLong(index++);
            obj.LibraryItemId = MapLong(index++);
            obj.PatronId = MapLong(index++);


            return obj;
        }
    }
}
