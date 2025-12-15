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
    public class BlogTagMappings : Profile
    {
        public BlogTagMappings()
        {
            CreateMap<BlogTag, ResultBlogTagDto>()
                .ForMember(d => d.Blog,
                    o => o.MapFrom(s => s.Blog == null ? null : s.Blog))
                .ForMember(d => d.Tag,
                    o => o.MapFrom(s => s.Tag == null ? null : s.Tag));


            CreateMap<Blog, ResultBlogDto>()
                .ForMember(d => d.BlogTags, o => o.Ignore()); 

            CreateMap<Tag, ResultTagDto>()
                .ForMember(d => d.BlogTags, o => o.Ignore()); 
        }
    }

}
