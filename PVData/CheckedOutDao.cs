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
    public class CheckedOutDao : ABaseDao
    {
        public CheckedOutDao()
            : base()
        {
            
        }


        public CheckedOutDao(string connectionString)
            : base(connectionString)
        {
            
        }


        public IList<CheckedOut> GetCheckedOut(CheckedOut obj)
        {
            IList<CheckedOut> lstReturn = null;
            CheckedOutMapper mapper = null;
            CheckedOut objReturn = null;

            command = null;
            reader = null;

            try
            {

                CreateSqlCommand("usp_get_checkedout");


                AddInputParmWithValue("@p_id", obj.Id);


                lstReturn = new List<CheckedOut>();

                reader = command.ExecuteReader();
                mapper = new CheckedOutMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (CheckedOut)mapper.DoMapping();
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
