using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOS.CategoryDtos
{
    public class ResultCategoryDto :BaseDto
    {
        public string CategoryImage { get; set; }
        public string CategoryName { get; set; }
        public IList<ResultBlogDto> Blogs { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
