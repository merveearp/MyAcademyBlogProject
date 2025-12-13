using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.ContactInfoDtos
{
    public class ResultContactInfoDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string OpenHours { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
