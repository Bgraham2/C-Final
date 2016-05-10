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
    public class DropDownEntryDao : ABaseDao
    {
        public DropDownEntryDao()
            : base()
        {
            
        }
    

        public DropDownEntryDao(string connectionString)
            : base(connectionString)
        {
            
        }

        public IList<DropDownEntry> GetDropDownEntryBasic()
        {
            command = null;
            reader = null;

            try
            {
                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.CommandText = "usp_get_users";

                command.Parameters.Add(new SqlParameter("@p_id",            null));
                command.Parameters.Add(new SqlParameter("@p_first_name",    null));
                command.Parameters.Add(new SqlParameter("@p_last_name",     null));
                command.Parameters.Add(new SqlParameter("@p_username",      null));
                command.Parameters.Add(new SqlParameter("@p_password",      null));

                reader = command.ExecuteReader();

                if(reader != null && reader.HasRows)
                {
                    while(reader.Read())
                    {
                        //PVLogger.TypedLogger(typeof(DropDownEntryDao)).Debug("");
                        PVLogger.TypedLogger(this.GetType()).Debug(reader.GetValue(0));
                        PVLogger.TypedLogger(this.GetType()).Debug(reader.GetValue(1));
                        PVLogger.TypedLogger(this.GetType()).Debug(reader.GetValue(2));
                        PVLogger.TypedLogger(this.GetType()).Debug(reader.GetValue(3));
                        PVLogger.TypedLogger(this.GetType()).Debug(reader.GetValue(4));
                        PVLogger.TypedLogger(this.GetType()).Debug(reader.GetValue(5));
                        PVLogger.TypedLogger(this.GetType()).Debug(reader.GetValue(6));
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
            return null;
        }

        public IList<DropDownEntry> GetAllDropDownEntrysZZZ()
        {
            IList<DropDownEntry> lstReturn = null;
            DropDownEntryMapper mapper = null;
            DropDownEntry objReturn = null;

            command = null;
            reader = null;

            try
            {

                command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.CommandText = "usp_get_users";

                command.Parameters.Add(new SqlParameter("@p_id", null));
                command.Parameters.Add(new SqlParameter("@p_first_name", null));
                command.Parameters.Add(new SqlParameter("@p_last_name", null));
                command.Parameters.Add(new SqlParameter("@p_username", null));
                command.Parameters.Add(new SqlParameter("@p_password", null));

                lstReturn = new List<DropDownEntry>();

                reader = command.ExecuteReader();
                mapper = new DropDownEntryMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (DropDownEntry)mapper.DoMapping();
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

        public IList<DropDownEntry> GetAllDropDownEntrys(string tableName)
        {
            IList<DropDownEntry> lstReturn = null;
            DropDownEntryMapper mapper = null;
            DropDownEntry objReturn = null;

            command = null;
            reader = null;

            try
            {

                CreateSqlCommand("usp_get_dropdowns");
                AddInputParmWithValue("@p_table_name", tableName);

      
                lstReturn = new List<DropDownEntry>();

                reader = command.ExecuteReader();
                mapper = new DropDownEntryMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (DropDownEntry)mapper.DoMapping();
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

        public IList<DropDownEntry> GetDropDownEntrys(DropDownEntry obj)
        {
            IList<DropDownEntry> lstReturn = null;
            DropDownEntryMapper mapper = null;
            DropDownEntry objReturn = null;
            object input = null;

            command = null;
            reader = null;

            try
            {

                CreateSqlCommand("usp_get_users");

                if (obj.Id >0)
                {
                    input = obj.Id;
                }
                else
                {
                    input = null;
                }

                AddInputParmWithValue("@p_id", input);
                //AddInputParmWithValue("@p_first_name", obj.FirstName);
                //AddInputParmWithValue("@p_last_name", obj.LastName);
                //AddInputParmWithValue("@p_username", obj.Username);
                //AddInputParmWithValue("@p_password", obj.Password);


                lstReturn = new List<DropDownEntry>();

                reader = command.ExecuteReader();
                mapper = new DropDownEntryMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (DropDownEntry)mapper.DoMapping();
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

        public DropDownEntry SaveDropDownEntry(string tableName, DropDownEntry obj)
        {

            object primaryKey = null;

            command = null;

            try
            {

                CreateSqlCommand("usp_save_dropdowns");

                if (obj.Id > 0)
                {
                    primaryKey = obj.Id;
                }
                else
                {
                    primaryKey = null;
                }

                AddInputOutputParmInt("@p_id", primaryKey);
                AddInputParmWithValue("@p_table_name", tableName);
                AddInputParmWithValue("@p_description", obj.Description);
                
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
