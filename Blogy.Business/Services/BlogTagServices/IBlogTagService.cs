using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Business.DTOs.TagDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.BlogTagServices
{
    public interface IBlogTagService 
    {
        Task<List<ResultTagDto>> GetTagsByBlogIdAsync(int blogId);
        Task<List<ResultBlogTagDto>> GetAllAsync();
        Task AddTagToBlogAsync(int blogId, int tagId);
        Task RemoveTagFromBlogAsync(int blogId, int tagId);

    }
}
