using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Abstract.Contract
{
    public class ChecklistDto
    {
        public string ChecklistName { get; set; }
        public List<string> ListFields { get; set; }
    }
}
