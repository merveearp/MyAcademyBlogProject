using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Business.DTOs.TagDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    public class BlogTagMappings :Profile
    {
        public BlogTagMappings()
        {
            CreateMap<BlogTag, ResultBlogTagDto>()
             .ForMember(dest => dest.Blog, opt => opt.MapFrom(src => src.Blog))
             .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.Tag));

            CreateMap<Blog, ResultBlogDto>();
            CreateMap<Tag, ResultTagDto>();
        }
    }
}
