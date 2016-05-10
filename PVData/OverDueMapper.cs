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
    public class OverDueMapper : ABaseMapper
    {
        OverDue obj;

        public OverDueMapper(SqlDataReader reader)
            :base(reader)
        {

        }

        public override object DoMapping()
        {
            int index = 0;

            obj = new OverDue();

            obj.Id = MapLong(index++);
            obj.Title = MapString(index++);
            obj.Isbn = MapString(index++);
            obj.FirstName = MapString(index++);
            obj.LastName = MapString(index++);
            obj.Phone = MapString(index++);
            obj.Email = MapString(index++);
            obj.DateCheckedOut = MapDateTime(index++);
            obj.DateDue = MapDateTime(index++); 

            return obj;
        }
    }
}
