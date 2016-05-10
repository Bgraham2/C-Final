using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class OverDue
    {
        private long id;
        private string title;
        private string isbn;
        private string firstName;
        private string lastName;
        private string phone;
        private string email;
        private DateTime dateCheckedOut;
        private DateTime dateDue;


        public OverDue()
        {


        }

        public OverDue(long id, string title, string isbn, string firstName, string lastName, string phone, string email, DateTime dateCheckedOut, DateTime dateDue)
        {
            Id = id;
            Title = title;
            Isbn = isbn;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            DateCheckedOut = dateCheckedOut;
            DateDue = dateDue;

        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public DateTime DateCheckedOut
        {
            get { return dateCheckedOut; }
            set { dateCheckedOut = value; }
        }
        public DateTime DateDue
        {
            get { return dateDue; }
            set { dateDue = value; }
        }
    }
}
