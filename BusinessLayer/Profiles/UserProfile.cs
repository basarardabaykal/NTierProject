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
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.firstname + " " + src.lastname))
                .ReverseMap()
                .ForMember(dest => dest.firstname, opt => opt.MapFrom(src => src.name.Substring(0, src.name.LastIndexOf(" "))))
                .ForMember(dest => dest.lastname, opt => opt.MapFrom(src => src.name.Split(new[] { ' ' })[src.name.Split(new[] { ' ' }).Length - 1]));

           //this parsing works with any number of names and a single word surname.
        }

    }
}
