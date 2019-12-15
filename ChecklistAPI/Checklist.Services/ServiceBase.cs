using AutoMapper;
using Checklist.DataLogic.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Services
{
    public class ServiceBase
    {
        protected IUnitOfWork _unitOfWork;
        protected IMapper _mapper;

        public ServiceBase(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    }
}
