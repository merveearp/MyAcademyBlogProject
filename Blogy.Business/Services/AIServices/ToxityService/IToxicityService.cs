using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AIServices.ToxityService
{
    public interface IToxicityService
    {
        Task<double> GetToxicityScoreAsync(string comment);
    }
}
