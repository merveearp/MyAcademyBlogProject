using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.BlogTagRepositories
{
    public class BlogTagRepository : IBlogTagRepository
    {
        protected readonly AppDbContext _context;

        public BlogTagRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<List<BlogTag>> GetAllAsync()
        {
            return await _context.BlogTags
                .Include(x => x.Blog)
                .Include(x => x.Tag)
                .ToListAsync();
        }

        public async Task<List<Tag>> GetTagsByBlogIdAsync(int blogId)
        {
            return await _context.BlogTags
                .Where(x => x.BlogId == blogId)
                .Include(x => x.Tag)
                .Select(x => x.Tag)
                .ToListAsync();
        }

        public async Task AddTagToBlogAsync(int blogId, int tagId)
        {
            var entity = new BlogTag
            {
                BlogId = blogId,
                TagId = tagId
            };

            await _context.BlogTags.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveTagFromBlogAsync(int blogId, int tagId)
        {
            var entity = await _context.BlogTags
                .FirstOrDefaultAsync(x => x.BlogId == blogId && x.TagId == tagId);

            if (entity != null)
            {
                _context.BlogTags.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }



}
