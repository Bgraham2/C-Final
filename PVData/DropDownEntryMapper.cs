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
    public class DropDownEntryMapper : ABaseMapper
    {
        DropDownEntry obj;

        public DropDownEntryMapper(SqlDataReader reader)
            :base(reader)
        {

        }

        public override object DoMapping()
        {
            int index = 0;

            obj = new DropDownEntry();

            obj.Id = MapLong(index++);
            obj.Description = MapString(index++);


            return obj;
        }
    }
}
