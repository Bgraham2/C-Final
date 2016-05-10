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
    public class CheckedOutMapper : ABaseMapper
    {
        CheckedOut obj;

        public CheckedOutMapper(SqlDataReader reader)
            :base(reader)
        {

        }

        public override object DoMapping()
        {
            int index = 0;

            obj = new CheckedOut();

            obj.CheckedOutID = MapLong(index++);
            obj.Id = MapLong(index++);
            obj.Title = MapString(index++);
            obj.Isbn = MapString(index++);
            obj.DateCheckedOut = MapDateTime(index++);
            obj.DueDate = MapDateTime(index++);
            obj.DateCheckedIn  = MapDateTime(index++);

           

            return obj;
        }
    }
}
