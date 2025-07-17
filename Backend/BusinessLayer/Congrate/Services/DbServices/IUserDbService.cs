using BusinessLayer.Dto;
using CoreLayer.Entity;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Congrate.Services.DbServices
{
    public interface IUserDbService : IGenericDbService<UserDTO>
    {
    }
}
