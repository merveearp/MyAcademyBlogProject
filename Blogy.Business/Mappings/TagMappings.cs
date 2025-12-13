using AutoMapper;
using Blogy.Business.DTOs.TagDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class TagMappings :Profile
    {
        public TagMappings()
        {
            CreateMap<ResultTagDto,Tag>().ReverseMap();
            CreateMap<CreateTagDto,Tag>().ReverseMap();
            CreateMap<UpdateTagDto,Tag>().ReverseMap();
        }
    }
}
