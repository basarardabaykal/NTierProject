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
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Firstname + " " + src.Lastname))
                .ReverseMap()
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.Name.Substring(0, src.Name.LastIndexOf(" "))))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.Name.Split(new[] { ' ' })[src.Name.Split(new[] { ' ' }).Length - 1]));

           //this parsing works with any number of names and a single word surname.
        }

    }
}
