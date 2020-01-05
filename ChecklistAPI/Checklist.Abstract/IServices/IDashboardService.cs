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
        Task<BasePlainResponse> Add(UserChecklistDto checklist, string userEmail);
        Task<ChecklistPlainResponse> GetLists(string userEmail);
    }
}
