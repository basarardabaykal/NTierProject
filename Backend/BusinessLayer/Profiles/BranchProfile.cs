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
    public class BranchProfile : Profile
    {
        public BranchProfile()
        {
            CreateMap<Branch, BranchDTO>()
                .ReverseMap()
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees));
        }
    }
}
