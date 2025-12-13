using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Business.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.TagDtos
{
    public class ResultTagDto:BaseDto
    {
        public string? Name { get; set; }
        public virtual IList<ResultBlogTagDto> BlogTags { get; set; }
    }
}
