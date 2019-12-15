using AutoMapper;
using Checklist.Abstract.Contract;
using Checklist.DataLogic.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checklist.Services.Mapper
{
    public class ApplicationProfile: Profile
    {
        public ApplicationProfile()
        {
            CreateMap<UserDto, User>()
                .ForMember(s => s.PasswordSalt, opt => opt.Ignore())
                .ForMember(s => s.Password, opt => opt.Ignore());

            CreateMap<User, UserDto>();

            CreateMap<AddressDto, Address>();

            CreateMap<Address, AddressDto>();
        }
    }
}
