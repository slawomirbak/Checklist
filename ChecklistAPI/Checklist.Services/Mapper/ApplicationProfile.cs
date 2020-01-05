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

            CreateMap<UserChecklistDto, UserChecklist>()
                .ForMember(c => c.User, opt => opt.Ignore());

            CreateMap<ChecklistFieldDto, ChecklistField>();

            CreateMap<ChecklistImageDto, ChecklistImage>();

            CreateMap<UserChecklist, UserChecklistDto>();

            CreateMap<ChecklistField, ChecklistFieldDto>()
                .ForMember(cf => cf.UserChecklist, opt => opt.Ignore());

            CreateMap<ChecklistImage, ChecklistImageDto>();

        }
    }
}
