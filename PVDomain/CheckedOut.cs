using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class CheckedOut
    {
        private long checkedOutID;
        private long id;
        private string title;
        private string isbn;
        private DateTime dateCheckedOut;
        private DateTime dueDate;
        private DateTime dateCheckedIn;


        public CheckedOut()
        {
            id = 0;


        }

        public CheckedOut(long id)
        {
            Id = id;


        }

        public CheckedOut(long checkedOutID, long id, string title, string isbn, DateTime dateCheckedOut, DateTime dueDate, DateTime dateCheckedIn)
        {
            CheckedOutID = checkedOutID;
            Id = id;
            Title = title;
            Isbn = isbn;
            DateCheckedOut = dateCheckedOut;
            DueDate = dueDate;
            DateCheckedIn = dateCheckedIn;
    

        }

        public long CheckedOutID
        {
            get { return checkedOutID; }
            set { checkedOutID = value; }
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

        public DateTime DateCheckedOut
        {

            get { return dateCheckedOut; }
            set { dateCheckedOut = value; }

        }
        public DateTime DueDate
        {

            get { return dueDate; }
            set 
            {
                dueDate = value; 
            }

        }

        public DateTime DateCheckedIn
        {

            get { return dateCheckedIn; }
            set 
            {
                dateCheckedIn = value;
            }

        }

    }
}
