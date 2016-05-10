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
    public class PublisherMapper : ABaseMapper
    {
        Publisher obj;

        public PublisherMapper(SqlDataReader reader)
            :base(reader)
        {

        }

        public override object DoMapping()
        {
            int index = 0;

            obj = new Publisher();

            obj.Id = MapLong(index++);
            obj.Name = MapString(index++);
            obj.Address  = MapString(index++);
            obj.Phone = MapString(index++);
            obj.Email = MapString(index++);
           

            return obj;
        }
    }
}
