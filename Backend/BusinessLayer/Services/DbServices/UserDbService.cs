using Microsoft.Identity.Client;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using BusinessLayer.Congrate.Services.DbServices;
using AutoMapper;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;

namespace BusinessLayer.Services.DbServices
{
    public class UserDbService : GenericDbService<UserDTO, AppUser>, IUserDbService
    {
        public UserDbService(IGenericRepository<AppUser> repo, IMapper mapper)
        : base(repo, mapper)
        {
        }
    }
}
