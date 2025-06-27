using CoreLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DbServices
{
    public interface IUserDbService
    {
        public Task LoadData(int id);

        public Task SendData(UserDTO userDTO);
    }
}
