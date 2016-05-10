using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class LibraryItem
    {

        private long id;
        private long itemTypeId;
        private long publisherId;
        private long authorId;
        private string title;
        private string isbn;


        public LibraryItem()
        {
            id = 0;
            itemTypeId = 0;
            publisherId = 0;
            authorId = 0;
            title = string.Empty;
            isbn = string.Empty;

        }

        public LibraryItem(long id, long itemTypeId, long publisherId, long authorId, string title, string isbn)
        {
            Id = id;
            ItemTypeId = itemTypeId;
            PublisherId = publisherId;
            AuthorId = authorId;
            Title = title;
            Isbn = isbn;
    

        }


        public long Id
        {

            get { return id; }
            set { id = value; }

        }

        public long ItemTypeId
        {

            get { return itemTypeId; }
            set { itemTypeId = value; }

        }

        public long PublisherId
        {

            get { return publisherId; }
            set { publisherId = value; }

        }

        public long AuthorId
        {

            get { return authorId; }
            set { authorId = value; }

        }
        public string Title
        {

            get { return title; }
            set 
            { 
                title = value; 
            }

        }

        public string Isbn
        {

            get { return isbn; }
            set 
            {
                isbn = value;
            }

        }

    }
}
