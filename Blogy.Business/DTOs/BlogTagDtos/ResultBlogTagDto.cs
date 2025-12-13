using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.TagDtos;
using Blogy.Business.DTOS.Common;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.BlogTagDtos
{
    public class ResultBlogTagDto :BaseDto
    {
        public int BlogId { get; set; }
        public virtual ResultBlogDto Blog { get; set; }

        public int TagId { get; set; }
        public virtual ResultTagDto Tag { get; set; }

    }
}
