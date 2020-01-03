using AutoMapper;
using Checklist.Abstract.IServices;
using Checklist.DataLogic.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Services.Services.DashboardService
{
    public class DashboardService : ServiceBase, IDashboardService
    {
        public DashboardService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
    }
}
