using Blogy.Business.DTOs.AIDtos;
using Blogy.Business.DTOs.TagDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AIServices.ContentService
{
    public interface IAIContentService
    {
        Task<ResultAIDto> CreateArticleAsync(CreateAIArticleDto articleDto);
        Task<ResultAIDto> CreateMessageAsync(string messageContent);
        Task<ResultAIDto> CreateAboutAsync(CreateAIAboutDto aboutDto);

    }
}
