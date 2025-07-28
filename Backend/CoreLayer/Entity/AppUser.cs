using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entity
{
    public class AppUser : IdentityUser<Guid>, IBaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Tcnumber { get; set; }
        public Guid? CompanyId { get; set; }
        public Guid? BranchId { get; set; }
        public Company? Company { get; set; }
        public Branch? Branch { get; set; }
    }
}
