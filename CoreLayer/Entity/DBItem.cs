using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entity
{
    public class DBItem
    {
        public int id { get; set; }
        public string name { get; set; }
        public string tcnumber { get; set; }

        public DBItem(string name, string tcnumber)
        {
            this.name = name;
            this.tcnumber = tcnumber;
        }
    }
}
