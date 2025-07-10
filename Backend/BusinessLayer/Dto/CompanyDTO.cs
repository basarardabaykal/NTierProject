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
        public string Name { get; set; }
        public ICollection<AppUser> Employees { get; set; }
    }
}
