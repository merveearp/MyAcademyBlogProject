using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Settings
{  
        public class OpenAiSettings
        {
            public string ApiKey { get; set; } = string.Empty;
            public string Model { get; set; } = "gpt-4o-mini";
        }
    }

