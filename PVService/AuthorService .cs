using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PVData;
using PVDomain;
using PVUtil;

namespace PVService
{
    public class AuthorService
    {
        AuthorDao authorDao;

        public IList<Author> GetAuthor(Author obj)
        {
            authorDao = new AuthorDao();
            return authorDao.GetAuthors(obj);
        }

        public Author SaveAuthor(Author obj)
        {

            StringBuilder sb = new StringBuilder();

            if (obj.Name.Length <= 0)
            {
                sb.Append("Authors Name is required<br/>");
            }

            if (obj.Address.Length <= 0)
            {
                sb.Append("An address is required<br/>");
            }

            if (obj.Phone.Length <= 0)
            {
                sb.Append("A phone number is required<br/>");
            }

            if (obj.Email.Length <= 0)
            {
                sb.Append("An email address is required<br/>");
            }

            if (sb.Length > 0)
            {
                throw new ApplicationException(sb.ToString());
            }
            authorDao = new AuthorDao();
            return authorDao.SaveAuthors(obj);
        }
    }
}
