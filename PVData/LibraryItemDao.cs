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
    public class LibraryItemDao : ABaseDao
    {
        public LibraryItemDao()
            : base()
        {
            
        }
    

        public LibraryItemDao(string connectionString)
            : base(connectionString)
        {
            
        }


        public IList<LibraryItem> GetLibraryItem(LibraryItem obj)
        {
            IList<LibraryItem> lstReturn = null;
            LibraryItemMapper mapper = null;
            LibraryItem objReturn = null;
            object inputID = null;
            object itemTypeID = null;
            object publisherID = null;
            object authorID = null;

            command = null;
            reader = null;

            try
            {

                CreateSqlCommand("usp_get_library_item");

                if (obj.Id >0)
                {
                    inputID = obj.Id;
                }
                else
                {
                    inputID = null;
                }

                if (obj.ItemTypeId > 0)
                {
                    itemTypeID = obj.ItemTypeId;
                }
                else
                {
                    itemTypeID = null;
                }

                if (obj.PublisherId > 0)
                {
                    publisherID = obj.PublisherId;
                }
                else
                {
                    publisherID = null;
                }

                if (obj.AuthorId > 0)
                {
                    authorID = obj.AuthorId;
                }
                else
                {
                    authorID = null;
                }

                AddInputParmWithValue("@p_id", inputID);
                AddInputParmWithValue("@p_item_type_id", itemTypeID);
                AddInputParmWithValue("@p_publisher_id", publisherID);
                AddInputParmWithValue("@p_author_id", authorID);
                AddInputParmWithValue("@p_title", obj.Title);
                AddInputParmWithValue("@p_isbn", obj.Isbn);

                lstReturn = new List<LibraryItem>();

                reader = command.ExecuteReader();
                mapper = new LibraryItemMapper(reader);

                if (reader != null && reader.HasRows)
                {
                    while (reader.Read())
                    {
                        objReturn = (LibraryItem)mapper.DoMapping();
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

        public LibraryItem SaveLibraryItem(LibraryItem obj)
        {

            object primaryKey = null;

            command = null;

            try
            {

                CreateSqlCommand("usp_save_library_item");

                if (obj.Id > 0)
                {
                    primaryKey = obj.Id;
                }
                else
                {
                    primaryKey = null;
                }

                 
                AddInputOutputParmInt("@p_id", primaryKey);
                AddInputParmWithValue("@p_item_type_id", obj.ItemTypeId);
                AddInputParmWithValue("@p_publisher_id", obj.PublisherId);
                AddInputParmWithValue("@p_author_id", obj.AuthorId);
                AddInputParmWithValue("@p_title", obj.Title);
                AddInputParmWithValue("@p_isbn", obj.Isbn);
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
