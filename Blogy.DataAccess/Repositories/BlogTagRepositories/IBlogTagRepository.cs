using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.BlogTagRepositories
{
    public interface IBlogTagRepository
    {       
        Task<List<Tag>> GetTagsByBlogIdAsync(int blogId);
        Task<List<BlogTag>> GetAllAsync();
        Task AddTagToBlogAsync(int blogId, int tagId);
        Task RemoveTagFromBlogAsync(int blogId, int tagId);

    }
}
