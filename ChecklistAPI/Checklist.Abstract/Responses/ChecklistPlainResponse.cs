using Checklist.Abstract.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Abstract.Validation
{
    public class ChecklistPlainResponse : BasePlainResponse
    {
        public List<UserChecklistDto> Data { get; set; } = new List<UserChecklistDto>();
    }
}
