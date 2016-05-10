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
    public class PublisherService
    {
        PublisherDao publisherDao;

        public IList<Publisher> GetPublisher(Publisher obj)
        {
            publisherDao = new PublisherDao();
            return publisherDao.GetPublisher(obj);
        }

        public Publisher SavePublisher(Publisher obj)
        {

            StringBuilder sb = new StringBuilder();

            if (obj.Name.Length <= 0)
            {
                sb.Append("Publishers Name is required<br/>");
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
            publisherDao = new PublisherDao();
            return publisherDao.SavePublisher(obj);
        }
    }
}
