using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UILayout
{
    public class _UILayoutRecentBlogsComponent :ViewComponent
    {
        private readonly IBlogService _blogService;
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
