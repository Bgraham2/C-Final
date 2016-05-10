using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class Author
    {

        private long id;
        private string name;
        private string address;
        private string phone;
        private string email;


        public Author()
        {
            id = 0;
            name = string.Empty;
            address = string.Empty;
            phone = string.Empty;
            email = string.Empty;
        }

        public Author(long id, string name, string address, string phone, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;     

        }


        public long Id
        {

            get { return id; }
            set { id = value; }

        }

        public string Name
        {

            get { return name; }
            set 
            { 
                name = value; 
            }

        }

        public string Address
        {

            get { return address; }
            set 
            {
                address = value;
            }

        }


        public string Phone
        {

            get { return phone; }
            set
            {

                phone = value;
            }

        }

        public string Email
        {

            get { return email; }
            set 
            {

              email = value;
           }

        }

    }
}
