using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Dto
{
    public class CompanyDTO
    {
        public string Id;
        public string Name;
        public ICollection<AppUser> Employees;
    }
}
