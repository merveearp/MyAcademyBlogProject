using Blogy.DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultBlogTagComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public _DefaultBlogTagComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            var tags = await _context.BlogTags
                .Where(x => x.BlogId == blogId)
                .Include(x => x.Tag)
                .Select(x => x.Tag)
                .ToListAsync();

            return View(tags);
        }
    }
}
