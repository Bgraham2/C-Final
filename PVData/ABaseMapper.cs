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
    public abstract class ABaseMapper
    {
        protected SqlDataReader reader;

        public ABaseMapper(SqlDataReader reader)
        {
            this.reader = reader;
        }

        public abstract Object DoMapping();

        public long MapLong(int index)
        {
            long rtnvalue;
            try
            {
                rtnvalue = reader.GetInt64(index);

            }
            catch (Exception ex)
            {
                rtnvalue = 0;
                //logging
            }

            return rtnvalue;
        }

        public string MapString(int index)
        {
            string rtnvalue;
            try
            {
                rtnvalue = reader.GetString(index);

            }
            catch (Exception ex)
            {
                rtnvalue = string.Empty;
                //logging
            }
            return rtnvalue;
        }

        public bool MapBoolean(int index)
        {
            bool rtnvalue;
            try
            {
                rtnvalue = reader.GetBoolean(index);

            }
            catch (Exception ex)
            {
                rtnvalue = false;
                //logging
            }
            return rtnvalue;
        }

        public byte MapByte(int index)
        {
            byte rtnvalue;
            try
            {
                rtnvalue = reader.GetByte(index);

            }
            catch (Exception ex)
            {
                rtnvalue = 0;
                //logging
            }
            return rtnvalue;
        }

        public int MapInt(int index)
        {
            int rtnvalue;
            try
            {
                rtnvalue = reader.GetInt32(index);

            }
            catch (Exception ex)
            {
                rtnvalue = 0;
                //logging
            }
            return rtnvalue;
        }
        public double MapDouble(int index)
        {
            double rtnvalue;
            try
            {
                rtnvalue = reader.GetDouble(index);

            }
            catch (Exception ex)
            {
                rtnvalue = 0;
                //logging
            }
            return rtnvalue;
        }

        public DateTime MapDateTime(int index)
        {
            DateTime rtnvalue;
            try
            {
                rtnvalue = reader.GetDateTime(index);

            }
            catch (Exception ex)
            {
                rtnvalue = DateTime.Now;
                //logging
            }
            return rtnvalue;
        }

        public double MapMoney(int index)
        {
            double rtnvalue;
            try
            {
                rtnvalue = Convert.ToDouble(reader.GetDecimal(index));

            }
            catch (Exception ex)
            {
                rtnvalue = 0;
                //logging
            }
            return rtnvalue;
        }
    }
}
