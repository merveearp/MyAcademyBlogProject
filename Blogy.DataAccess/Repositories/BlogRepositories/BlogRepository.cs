using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.BlogRepositories
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Blog>> GetBlogsByCategoryIdAsync(int categoryId)
        {
            return await _table.Include(x => x.Category).Where(x => x.CategoryId == categoryId).ToListAsync();
        }

        public Task<List<Blog>> GetBlogsByWriterIdAsync(int writerId)
        {
            return _table.Where(x => x.WriterId == writerId).ToListAsync();
        }

        public async Task<List<Blog>> GetBlogsWithCategoriesAsync()
        {
            return await _table.Include(x =>x.Category).ToListAsync();
        }

        public async Task<Blog> GetByIdWithTagsAsync(int id)
        {
            
            return await _context.Blogs
                .Include(b => b.BlogTags)
                    .ThenInclude(bt => bt.Tag)
                .FirstOrDefaultAsync(b => b.Id == id);
        }
        

        public async Task<List<Blog>> GetLast3BlogsAsync()
        {
            return await _table.OrderByDescending(x => x.Id).Take(3).ToListAsync();
        }
    }
}
