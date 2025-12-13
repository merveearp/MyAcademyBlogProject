using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class AboutMappings :Profile
    {
        public AboutMappings()
        {
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();
        }
    }
}
