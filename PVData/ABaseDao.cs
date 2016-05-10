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


namespace PVData
{

    //Various Types of "GETTER" sprocs
    // -- returns: recordset
    // -- returns: recordset with a RETURN Value
    // -- returns: recordset with an OUTPUT parameter(s)
    // -- returns: recordset with an OUTPUT parameter(s) and a RETURN value
    // -- returns: RETURN Value 
    // -- returns: OUTPUT parameter(s)
    // -- returns: OUTPUT parameter(s) an a RETURN value

    public abstract class ABaseDao
    {
        protected string connectionString;
        protected SqlConnection connection;
        protected SqlCommand command;
        protected SqlDataReader reader;

        public ABaseDao()
        {
            connectionString = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
            connectionString = ConfigurationManager.AppSettings["connection_string"];
            OpenConnection();

        }

        public ABaseDao(string connectionString)
        {
            this.connectionString = connectionString;
            OpenConnection();
            
        }

        protected void OpenConnection()
        {


            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                PVLogger.TypedLogger(this.GetType()).Error(ex.Message);
            }
        }

        protected void CloseConnection()
        {
            try
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            catch (Exception ex)
            {
                PVLogger.TypedLogger(this.GetType()).Error(ex.Message);
            }
        }

        protected void CloseReader()
        {
            try
            {
                if (reader != null)
                {
                    reader.Close();
                    reader.Dispose();
                }
            }
            catch (Exception ex)
            {
                PVLogger.TypedLogger(this.GetType()).Error(ex.Message);
            }
        }

        protected void CloseCommand()
        {
            try
            {
                if (command != null)
                {
                    command.Dispose();
                }
            }
            catch (Exception ex)
            {
                PVLogger.TypedLogger(this.GetType()).Error(ex.Message);
            }
        }

        protected void CloseResources()
        {
                CloseReader();
                CloseConnection();
                CloseCommand();
        }

        protected void CreateSqlCommand(string sprocName)
        {

            command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.CommandText = sprocName;

        }

        protected void AddInputParmNull(string paraName)
        {
            SqlParameter parm = new SqlParameter(paraName, null);
            command.Parameters.Add(parm);
        }

        protected void AddInputParmWithValue(string paraName, Object value)
        {
            SqlParameter parm = new SqlParameter(paraName, value);
            parm.Size = 100;
            command.Parameters.Add(parm);
        }

        protected void AddOutputParmInt(string paraName)
        {
            SqlParameter parm = new SqlParameter(paraName, SqlDbType.Int);
            parm.Size = 4;
            parm.Direction = ParameterDirection.Output;
            command.Parameters.Add(parm);
        }

        protected void AddInputOutputParmInt(string paraName, Object value)
        {
            SqlParameter parm = new SqlParameter(paraName, value);
            parm.Size = 4;
            parm.Direction = ParameterDirection.InputOutput;
            command.Parameters.Add(parm);
        }

        protected void AddReturnValueInt(string paraName)
        {
            SqlParameter parm = new SqlParameter();
            parm.ParameterName = paraName;
            parm.DbType = DbType.Int32;
            parm.Direction = ParameterDirection.ReturnValue;
            command.Parameters.Add(parm);
        }
    }
}
