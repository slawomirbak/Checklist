using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic.Entities
{
    public class UserChecklist:BaseEntity
    {
        public string Name { get; set; }
        public List<ChecklistField> Fields { get; set; }
        public DateTime CreatedDate { get; set; }
        public User User { get; set; }
    }
}
