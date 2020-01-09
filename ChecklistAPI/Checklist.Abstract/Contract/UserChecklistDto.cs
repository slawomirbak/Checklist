using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Abstract.Contract
{
    public class UserChecklistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ChecklistFieldDto> Fields { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<ChecklistImageDto> ChecklistImages { get; set; }
    }
}
