using BusinessLayer.Congrate.Services;
using BusinessLayer.Congrate.Services.ControllerServices;
using BusinessLayer.Congrate.Services.DbServices;
using BusinessLayer.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.ControllerServices
{
    public class BranchControllerService : GenericControllerService<BranchDTO>, IBranchControllerService
    {
        public BranchControllerService(IGenericDbService<BranchDTO> dbService) : base(dbService) { }
    }
}
