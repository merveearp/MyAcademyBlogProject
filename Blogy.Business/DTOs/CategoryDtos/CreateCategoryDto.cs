using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOS.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string? Name { get; set; }
        public string CategoryImage { get; set; }
    }
}
