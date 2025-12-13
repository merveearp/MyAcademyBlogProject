using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultBlogsComponent :ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultBlogsComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetCategoriesWithBlogsAsync();

            var lastBlogs = values.OrderByDescending(x => x.Id).Take(5).ToList();
            return View(lastBlogs);
        }
    }
}
