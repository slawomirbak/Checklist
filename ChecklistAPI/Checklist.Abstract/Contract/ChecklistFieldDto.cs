using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Abstract.Contract
{
    public class ChecklistFieldDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
        public List<ChecklistImageDto> ChecklistImages { get; set; }
        public UserChecklistDto UserChecklist { get; set; }
    }
}
