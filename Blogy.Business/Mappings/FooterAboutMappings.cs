using AutoMapper;
using Blogy.Business.DTOs.FooterAboutDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class FooterAboutMappings : Profile
    {
        public FooterAboutMappings()
        {
            CreateMap<FooterAbout, ResultFooterAboutDto>().ReverseMap();
            CreateMap<FooterAbout, CreateFooterAboutDto>().ReverseMap();
            CreateMap<FooterAbout, UpdateFooterAboutDto>().ReverseMap();
        }
    }

}
