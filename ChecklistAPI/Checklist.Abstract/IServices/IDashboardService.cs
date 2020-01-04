using Checklist.Abstract.Contract;
using Checklist.Abstract.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Abstract.IServices
{
    public interface IDashboardService
    {
        Task<BasePlainResponse> Add(ChecklistDto checklist, string userEmail);
    }
}
