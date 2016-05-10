using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class LogIn
    {

        private long id;
        private long patronTypeId;
        private string firstName;
        private string lastName;
        private string username;
        private string password;
        private string phone;
        private string email;
        private bool active;


        public LogIn()
        {
            id = 0;
            patronTypeId = 0;
            firstName = string.Empty;
            lastName = string.Empty;
            username = string.Empty;
            password = string.Empty;
            phone = string.Empty;
            email = string.Empty;
            active = true;

        }

        public LogIn(long id, long patronTypeId, string firstName, string lastName, string username, string password)
        {
            Id = id;
            PatronTypeId = patronTypeId;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
            Phone = phone;
            Email = email;
            Active = active;

        }

        public long Id
        {

            get { return id; }
            set { id = value; }

        }

        public long PatronTypeId
        {

            get { return patronTypeId; }
            set { patronTypeId = value; }

        }
        public string FirstName
        {

            get { return firstName; }
            set 
            {
                firstName = value; 
            }

        }

        public string LastName
        {

            get { return lastName; }
            set
            {
                lastName = value;
            }

        }

        public string Username
        {

            get { return username; }
            set
            {
                username = value;
            }

        }
        public string Password
        {

            get { return password; }
            set 
            {
                password = value;
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

        public bool Active
        {

            get { return active; }
            set
            {

                active = value;
            }

        }
        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }

        }

    }
}
