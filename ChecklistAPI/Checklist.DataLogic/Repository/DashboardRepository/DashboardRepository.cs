using Checklist.DataLogic.Entities;
using Checklist.DataLogic.Repository.Dapper;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Checklist.DataLogic.Repository.DashboardRepository
{
    public class DashboardRepository : BaseRepository<UserChecklist>, IDashboardRepository
    {
        public DashboardRepository(DefaultContext context,IDbConnection connection, ISqlQueries sqlQueries): base(context, connection, sqlQueries, "UserChecklist")
        {
        }

        public async Task<List<UserChecklist>> GetLists(int userId)
        {
            //Dapper
            //var queryTest = GetSqlQuery(paramId: userId);
            //var userChecklist = await Connection.QueryAsync<UserChecklist>(GetSqlQuery(paramId: userId));

            var userChecklist = await _context.UserChecklists.Where(cl => cl.User.Id == userId).Include(cl => cl.Fields).Include(cl => cl.ChecklistImages).ToListAsync();
            return userChecklist.ToList();
        }
        
        public async Task<bool> DoesChecklistBelongToUser(int checklistId, string email)
        {
            return await _context.UserChecklists.AnyAsync(uc => uc.Id == checklistId && uc.User.Email == email);
        }

        public async Task<UserChecklist> AddUserChecklistImage(int checklistId, string ImageName)
        {
            var userChecklist = await _context.UserChecklists.FirstOrDefaultAsync(uc => uc.Id == checklistId);
            var checklistImage = new ChecklistImage(ImageName, $"https://checklist-image.s3.eu-central-1.amazonaws.com/" + ImageName);
            if(userChecklist.ChecklistImages == null)
            {
                userChecklist.ChecklistImages = new List<ChecklistImage>();
            }
            userChecklist.ChecklistImages.Add(checklistImage);
            _context.UserChecklists.Update(userChecklist);
            return userChecklist;
        }
        public void Update(UserChecklist userChecklist)
        {
             _context.UserChecklists.Update(userChecklist);
        }
        public async Task Delete(int checklistId)
        {
            var userCheckklist = await GetListById(checklistId);
            _context.Remove(userCheckklist);
        }

        public async Task<UserChecklist> GetListById(int checklistId)
        {
            return await _context.UserChecklists.Include(uc => uc.ChecklistImages).Include(uc => uc.Fields).FirstOrDefaultAsync(uc => uc.Id == checklistId);
        }
    }
}
