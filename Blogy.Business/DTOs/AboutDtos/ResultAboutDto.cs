using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.DTOs.AboutDtos
{
    public class ResultAboutDto
    {

        public int Id { get; set; }

        public string AboutTitle { get; set; }
        public string TitleImage { get; set; }


        public string Section1Title { get; set; }
        public string Section1Content { get; set; }
        public string Section1Image { get; set; }


        public string Section2Title { get; set; }
        public string Section2Content { get; set; }
        public string Section2Image { get; set; }

    }
}
