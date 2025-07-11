using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Repository
{
    public interface IAuthRepository
    {
        public Task Login();
    }
}
