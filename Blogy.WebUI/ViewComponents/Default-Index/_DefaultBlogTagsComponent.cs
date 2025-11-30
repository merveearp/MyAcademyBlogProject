using Blogy.Business.DTOs.BlogDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultBlogTagsComponent :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(ResultBlogDto blog)
        {
            return View(blog);
        }
    }
}
