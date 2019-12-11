using Checklist.Abstract.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Checklist.Abstract.IServices
{
    public interface IUserService
    {
        Task Add(UserDto userDto);
    }
}
