using BusinessLayer.Congrate.Repository;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using BusinessLayer.Congrate.Services.DbServices;
using AutoMapper;
using CoreLayer.Utilities.Interfaces;
using CoreLayer.Utilities.Results;
using CoreLayer.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DbServices
{
    public class CompanyDbService : DbService<CompanyDTO, Company>, ICompanyDbService
    {
        public CompanyDbService(IRepository<Company> repo, IMapper mapper)
        : base(repo, mapper)
        {
        }
    }
}
