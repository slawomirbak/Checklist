using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Abstract.Contract
{
    public class TokensDto
    {
        public string Jwt { get; set; }
        public string refreshToken { get; set; }
    }
}
