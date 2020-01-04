using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic.Entities
{
    public class ChecklistField:BaseEntity
    {
        public string Name { get; set; }
        public bool Completed { get; set; }
        public List<ChecklistImage> ChecklistImages { get; set; }    
        public UserChecklist UserChecklist { get; set; }
    }
}
