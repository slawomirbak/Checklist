using Checklist.Abstract.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Abstract.Validation
{
    public class LoginPlainResponse: BasePlainResponse
    {
        public TokensDto Data { get; set; }
    }
}
