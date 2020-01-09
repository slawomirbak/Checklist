using Checklist.DataLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.DataLogic.Repository.DashboardRepository
{
    public interface IDashboardRepository
    {
        Task Create(UserChecklist entity);
        Task <List<UserChecklist>> GetLists(int userId);
        Task<bool> DoesChecklistBelongToUser(int checklistId, string email);
        Task<UserChecklist> AddUserChecklistImage(int checklistId, string ImageName);
        void Update(UserChecklist userChecklist);
        Task Delete(int checklistId);
        Task<UserChecklist> GetListById(int checklistId);
    }
}
