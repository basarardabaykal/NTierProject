using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entity
{
    public class Company
    {
        public string Id;
        public string Name;
        public ICollection<AppUser> Employees;
    }
}
