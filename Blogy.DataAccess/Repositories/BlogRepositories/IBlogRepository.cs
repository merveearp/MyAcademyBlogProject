using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.BlogRepositories
{
    public interface IBlogRepository :IGenericRepository<Blog>
    {
        Task<Blog> GetByIdWithTagsAsync(int id);
        Task<List<Blog>> GetBlogsWithCategoriesAsync();
        Task<List<Blog>> GetBlogsByCategoryIdAsync(int categoryId);
        Task<List<Blog>> GetLast3BlogsAsync();
        Task<List<Blog>> GetBlogsByWriterIdAsync(int writerId);
        Task<List<Blog>> GetAllWithTagsAsync();

    }
}
 