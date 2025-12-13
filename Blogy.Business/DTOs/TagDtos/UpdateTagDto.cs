using Blogy.Business.DTOS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.TagDtos
{
    public class UpdateTagDto :BaseDto
    {
        public string? Name { get; set; }
    }
}
