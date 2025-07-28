using AutoMapper;
using BusinessLayer.Congrate.Repository;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using CoreLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.DbServices
{
    public class BranchDbService: GenericDbService<BranchDTO, Branch>, IBranchDbService
    {
        public BranchDbService(IGenericRepository<Branch> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
