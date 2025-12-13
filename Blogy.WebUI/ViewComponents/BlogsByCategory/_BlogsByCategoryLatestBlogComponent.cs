using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.BlogsByCategory
{
    public class _BlogsByCategoryLatestBlogComponent :ViewComponent
    {
        private readonly IBlogService _blogService;

        public _BlogsByCategoryLatestBlogComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _blogService.GetLast3BlogsAsync();
            return View(values);
        }
    }
}
