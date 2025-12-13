using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Business.DTOS.CategoryDtos;
using Blogy.Business.DTOS.Common;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.BlogDtos
{
    public class ResultBlogDto :BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string BlogImage1 { get; set; }
        public string BlogImage2 { get; set; }
        public int CategoryId { get; set; }
        public int WriterId { get; set; }

        public ResultCategoryDto Category { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public IList<ResultBlogTagDto> BlogTags { get; set; } 
        public ResultUserDto? Writer { get; set; }
        public IList<ResultCommentDto> Comments { get; set; }
    }

}

