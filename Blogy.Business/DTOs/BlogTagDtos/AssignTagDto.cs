using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.BlogTagDtos
{
    public class AssignTagDto
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public string TagName { get; set; }
        public bool TagExists { get; set; }
    }
}
