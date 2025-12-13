using AutoMapper;
using Blogy.Business.DTOs.ContactInfoDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class ContactInfoMappings:Profile
    {
        public ContactInfoMappings()
        {
            CreateMap<ResultContactInfoDto, ContactInfo>().ReverseMap();
            CreateMap<CreateContactInfoDto, ContactInfo>().ReverseMap();
            CreateMap<UpdateContactInfoDto, ContactInfo>().ReverseMap();
        }
    }
}
