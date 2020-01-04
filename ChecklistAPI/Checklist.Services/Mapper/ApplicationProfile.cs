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

            CreateMap<ChecklistDto, UserChecklist>()
                .ForMember(c => c.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(c => c.Fields, opt => opt.MapFrom(x => ChecklistFieldCreator(x.ListFields)));
        }

        private List<ChecklistField> ChecklistFieldCreator(List<string> checklistNames)
        {
            var checklistFields = new List<ChecklistField>();
            foreach (var item in checklistNames)
            {
                checklistFields.Add(new ChecklistField(item));
            }

            return checklistFields;
        }
    }
}
