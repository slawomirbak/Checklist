using Checklist.Abstract.Contract;
using Checklist.Abstract.Validation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Abstract.IServices
{
    public interface IUserService
    {
        Task<BasePlainResponse> Add(UserDto userDto);
        Task<LoginPlainResponse> Login(CredentialDto credentials);
        Task<LoginPlainResponse> GetTokens(string token);
    }
}
