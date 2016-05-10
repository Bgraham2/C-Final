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
    public class PatronMapper : ABaseMapper
    {
        Patron obj;

        public PatronMapper(SqlDataReader reader)
            :base(reader)
        {

        }

        public override object DoMapping()
        {
            int index = 0;

            obj = new Patron();

            obj.Id = MapLong(index++);
            obj.PatronTypeId = MapLong(index++);
            obj.FirstName = MapString(index++);
            obj.LastName = MapString(index++);
            obj.Username = MapString(index++);
            obj.Password  = MapString(index++);
            obj.Phone = MapString(index++);
            obj.Email = MapString(index++);
            obj.Active = MapBoolean(index++);
           

            return obj;
        }
    }
}
