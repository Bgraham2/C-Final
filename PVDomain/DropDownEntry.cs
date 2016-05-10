using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PVDomain
{
    public class DropDownEntry
    {

        private long id;
        private string description;


        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }


        public DropDownEntry(long id, string description)
        {
            this.id = id;
            this.description = description;
            
        }

        public DropDownEntry()
        {
            this.id = 0;
            this.description = string.Empty;

        }

    }
}
