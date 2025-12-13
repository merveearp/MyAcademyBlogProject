using AutoMapper;
using Blogy.Business.DTOs.SocialDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class SocialMappings :Profile
    {
        public SocialMappings()
        {
            CreateMap<Social , ResultSocialDto >().ReverseMap();
            CreateMap<Social , CreateSocialDto >().ReverseMap();
            CreateMap<Social , UpdateSocialDto >().ReverseMap();
        }
    }
}
