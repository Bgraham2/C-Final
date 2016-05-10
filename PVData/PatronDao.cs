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
    public class PatronDao : ABaseDao
    {
        public PatronDao()
            : base()
        {
            
        }
    

        public PatronDao(string connectionString)
            : base(connectionString)
        {
            
        }


        public IList<Patron> GetPatrons(Patron obj)
        {
            IList<Patron> lstReturn = null;
            PatronMapper mapper = null;
            Patron objReturn = null;
            object inputID = null;
            object patronID = null;

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

                AddInputParmWithValue("@p_id", inputID);
                AddInputParmWithValue("@p_patron_type_id", patronID);
                AddInputParmWithValue("@p_first_name", obj.FirstName);
                AddInputParmWithValue("@p_last_name", obj.LastName);
                AddInputParmWithValue("@p_username", obj.Username);
                AddInputParmWithValue("@p_password", obj.Password);
                //AddInputParmWithValue("@p_phone", obj.Phone);
                //AddInputParmWithValue("@p_email", obj.Email);
                //AddInputParmWithValue("@p_active", obj.Active);


                lstReturn = new List<Patron>();

                reader = command.ExecuteReader();
                mapper = new PatronMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (Patron)mapper.DoMapping();
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

        public Patron SavePatron(Patron obj)
        {

            object primaryKey = null;
            object activeValue = null;

            command = null;

            try
            {

                CreateSqlCommand("usp_save_patron");

                if (obj.Id > 0)
                {
                    primaryKey = obj.Id;
                }
                else
                {
                    primaryKey = null;
                }

                if (obj.Active == true)
                {
                    activeValue = 1;
                }
                else
                {
                    activeValue = 0;
                }
                 
                AddInputOutputParmInt("@p_id", primaryKey);
                AddInputParmWithValue("@p_patron_type_id", obj.PatronTypeId);
                AddInputParmWithValue("@p_first_name", obj.FirstName);
                AddInputParmWithValue("@p_last_name", obj.LastName);
                AddInputParmWithValue("@p_username", obj.Username);
                AddInputParmWithValue("@p_password", obj.Password);
                AddInputParmWithValue("@p_phone", obj.Phone);
                AddInputParmWithValue("@p_email", obj.Email);
                AddInputParmWithValue("@p_active", activeValue);
                AddInputParmWithValue("@p_debug", 0);

                command.ExecuteNonQuery();
                obj.Id = Convert.ToInt32(command.Parameters[0].Value.ToString());
                
                

            }
            catch (Exception ex)
            {
                PVLogger.TypedLogger(this.GetType()).Error(ex.Message);
                throw new Exception("Username is already used, please choose another!");
            }

            finally
            {
                CloseResources();
            }

            return obj;
        }

        public Patron EditPatron(Patron obj)
        {

            object primaryKey = null;
            object activeValue = null;

            command = null;

            try
            {

                CreateSqlCommand("usp_edit_patron");

                if (obj.Id > 0)
                {
                    primaryKey = obj.Id;
                }
                else
                {
                    primaryKey = null;
                }

                if (obj.Active == true)
                {
                    activeValue = 1;
                }
                else
                {
                    activeValue = 0;
                }

                AddInputOutputParmInt("@p_id", primaryKey);
                AddInputParmWithValue("@p_patron_type_id", obj.PatronTypeId);
                AddInputParmWithValue("@p_first_name", obj.FirstName);
                AddInputParmWithValue("@p_last_name", obj.LastName);
                AddInputParmWithValue("@p_username", obj.Username);
                AddInputParmWithValue("@p_password", obj.Password);
                AddInputParmWithValue("@p_phone", obj.Phone);
                AddInputParmWithValue("@p_email", obj.Email);
                AddInputParmWithValue("@p_active", activeValue);
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
