using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Dto;
using CoreLayer.Entity;


namespace BusinessLayer.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserDTO>()

                .ReverseMap();

           //this parsing works with any number of names and a single word surname.
        }

    }
}
