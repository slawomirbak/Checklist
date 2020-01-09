using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.DataLogic.Entities
{
    public class ChecklistImage:BaseEntity
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public ChecklistImage(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
