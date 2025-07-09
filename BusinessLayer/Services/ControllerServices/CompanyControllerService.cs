using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using BusinessLayer.Congrate.Services.ControllerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Utilities.Interfaces;
using AutoMapper;


namespace BusinessLayer.Services.ControllerServices
{
    public class CompanyControllerService : ControllerService<CompanyDTO>, ICompanyControllerService
    {
        public CompanyControllerService(IDbService<CompanyDTO> dbService) : base(dbService) { } 

    }
}
