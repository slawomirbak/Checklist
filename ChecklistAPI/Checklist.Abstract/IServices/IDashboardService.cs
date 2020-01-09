using Checklist.Abstract.Contract;
using Checklist.Abstract.Validation;
using Microsoft.AspNetCore.Http;
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
        Task<BasePlainResponse> UploadImage(IFormFile file, int checklistId, string emial);
        Task<BasePlainResponse> Update(UserChecklistDto userChecklistDto, string userEmail);
        Task<BasePlainResponse> Delete(int userChecklitId, string userEmail);
    }
}
