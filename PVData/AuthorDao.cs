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
    public class AuthorDao : ABaseDao
    {
        public AuthorDao()
            : base()
        {
            
        }
    

        public AuthorDao(string connectionString)
            : base(connectionString)
        {
            
        }


        public IList<Author> GetAuthors(Author obj)
        {
            IList<Author> lstReturn = null;
            AuthorMapper mapper = null;
            Author objReturn = null;
            object inputID = null;

            command = null;
            reader = null;

            try
            {

                CreateSqlCommand("usp_get_authors");

                if (obj.Id >0)
                {
                    inputID = obj.Id;
                }
                else
                {
                    inputID = null;
                }


                AddInputParmWithValue("@p_id", inputID);
                AddInputParmWithValue("@p_name", obj.Name);
                AddInputParmWithValue("@p_address", obj.Address);
                AddInputParmWithValue("@p_phone", obj.Phone);
                AddInputParmWithValue("@p_email", obj.Email);


                lstReturn = new List<Author>();

                reader = command.ExecuteReader();
                mapper = new AuthorMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (Author)mapper.DoMapping();
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

        public Author SaveAuthors(Author obj)
        {

            object primaryKey = null;

            command = null;

            try
            {

                CreateSqlCommand("usp_save_author");

                if (obj.Id > 0)
                {
                    primaryKey = obj.Id;
                }
                else
                {
                    primaryKey = null;
                }

                 
                AddInputOutputParmInt("@p_id", primaryKey);
                AddInputParmWithValue("@p_name", obj.Name);
                AddInputParmWithValue("@p_address", obj.Address);
                AddInputParmWithValue("@p_phone", obj.Phone);
                AddInputParmWithValue("@p_email", obj.Email);
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
