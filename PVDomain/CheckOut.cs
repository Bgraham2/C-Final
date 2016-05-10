using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class CheckOut
    {

        private long id;
        private long libraryItemId;
        private long patronId;

        public CheckOut()
        {
            id = 0;
            libraryItemId = 0;
            patronId = 0;
        }

        public CheckOut(long id)
        {
            Id = id;
        }

        public CheckOut(long id, long libraryItemId, long patronId)
        {
            Id = id;
            LibraryItemId = libraryItemId;
            PatronId = patronId;
        }

        public long Id
        {

            get { return id; }
            set { id = value; }

        }

        public long LibraryItemId
        {

            get { return libraryItemId; }
            set { libraryItemId = value; }

        }

        public long PatronId
        {

            get { return patronId; }
            set { patronId = value; }

        }

    }
}
