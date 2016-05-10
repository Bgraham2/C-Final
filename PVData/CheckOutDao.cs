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
    public class CheckOutDao : ABaseDao
    {
        public CheckOutDao()
            : base()
        {
            
        }


        public CheckOutDao(string connectionString)
            : base(connectionString)
        {
            
        }

        public CheckOut SaveCheckOut(CheckOut obj)
        {

            object primaryKey = null;

            command = null;

            try
            {

                CreateSqlCommand("usp_save_checked_out_item");

                if (obj.Id > 0)
                {
                    primaryKey = obj.Id;
                }
                else
                {
                    primaryKey = null;
                }


                AddInputOutputParmInt("@p_id", primaryKey);
                AddInputParmWithValue("@p_library_item_id", obj.LibraryItemId);
                AddInputParmWithValue("@p_patron_id", obj.PatronId);
                AddInputParmWithValue("@p_debug", 0);

                command.ExecuteNonQuery();
                obj.Id = Convert.ToInt32(command.Parameters[0].Value.ToString());



            }
            catch (Exception ex)
            {
                PVLogger.TypedLogger(this.GetType()).Error(ex.Message);
            }

            finally
            {
                CloseResources();
            }

            return obj;
        }

    }
}
