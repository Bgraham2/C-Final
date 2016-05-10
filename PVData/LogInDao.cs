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
    public class LogInDao : ABaseDao
    {
        public LogInDao()
            : base()
        {
            
        }


        public LogInDao(string connectionString)
            : base(connectionString)
        {
            
        }


        public IList<LogIn> GetLogIn(LogIn obj)
        {
            IList<LogIn> lstReturn = null;
            LogInMapper mapper = null;
            LogIn objReturn = null;
            object inputID = null;
            object patronID = null;
            object password = null;

            command = null;
            reader = null;

            try
            {

                CreateSqlCommand("usp_get_patron");

                if (obj.Id >0)
                {
                    inputID = obj.Id;
                }
                else
                {
                    inputID = null;
                }

                if (obj.PatronTypeId > 0)
                {
                    patronID = obj.PatronTypeId;
                }
                else
                {
                    patronID = null;
                }

                password = obj.Password;
                obj.Password = "";

                AddInputParmWithValue("@p_id", inputID);
                AddInputParmWithValue("@p_patron_type_id", patronID);
                AddInputParmWithValue("@p_first_name", obj.FirstName);
                AddInputParmWithValue("@p_last_name", obj.LastName);
                AddInputParmWithValue("@p_username", obj.Username);
                AddInputParmWithValue("@p_password", obj.Password);
                //AddInputParmWithValue("@p_phone", obj.Phone);
                //AddInputParmWithValue("@p_email", obj.Email);
                //AddInputParmWithValue("@p_active", obj.Active);


                lstReturn = new List<LogIn>();

                reader = command.ExecuteReader();
                mapper = new LogInMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (LogIn)mapper.DoMapping();
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

            if (BCrypt.CheckPassword(Convert.ToString(password), lstReturn.ElementAt(0).Password.ToString()) == true)
            {
                return lstReturn;
            }
            else
            {
                lstReturn = null;
                return lstReturn;
            }

        }

    }
}
