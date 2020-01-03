using AutoMapper;
using Checklist.Abstract.Contract;
using Checklist.Abstract.IServices;
using Checklist.Abstract.Validation;
using Checklist.DataLogic.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Services.Services.DashboardService
{
    public class DashboardService : ServiceBase, IDashboardService
    {
        public DashboardService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<BasePlainResponse> Add(ChecklistDto checklist)
        {
            var test = new BasePlainResponse();
            return test;
        }
    }
}
