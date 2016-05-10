using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVDomain;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using PVUtil;
using log4net;
using System.Configuration;

namespace PVData
{
    public class OverDueDao : ABaseDao
    {
        public OverDueDao()
            : base()
        {
            
        }


        public OverDueDao(string connectionString)
            : base(connectionString)
        {
            
        }


        public IList<OverDue> GetOverDue(OverDue obj)
        {
            IList<OverDue> lstReturn = null;
            OverDueMapper mapper = null;
            OverDue objReturn = null;

            command = null;
            reader = null;

            try
            {

                CreateSqlCommand("usp_get_overdue");


                lstReturn = new List<OverDue>();

                reader = command.ExecuteReader();
                mapper = new OverDueMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (OverDue)mapper.DoMapping();
                        lstReturn.Add(objReturn);
                    }
                }

            }
            catch (Exception ex)
            {
                PVLogger.TypedLogger(this.GetType()).Error(ex.Message);
            }

            finally
            {
                CloseResources();
            }

            return lstReturn;
        }

    }
}
