using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreLayer.Entity
{
    public class Company : IBaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name  {get; set; }
        public ICollection<AppUser> Employees  {get; set; } = new List<AppUser>();
        public ICollection<Branch> Branches {get; set; } = new List<Branch>();
    }
}
