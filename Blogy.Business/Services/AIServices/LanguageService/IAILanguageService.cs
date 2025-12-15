using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AIServices.LanguageService
{
    public interface IAILanguageService
    {
        Task<string> TranslateAsync(string comment);
        bool HasTurkishCharacters(string text);
    }
}
