using AutoMapper;
using Blogy.Business.DTOs.ContactMessageDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class ContactMessageMappings :Profile
    {
        public ContactMessageMappings()
        {
            CreateMap<ResultContactMessageDto, ContactMessage>().ReverseMap();
            CreateMap<CreateContactMessageDto, ContactMessage>().ReverseMap();

        }
    }
}
