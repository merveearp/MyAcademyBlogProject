using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.UILayout
{
    public class _UILayoutMenuComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _UILayoutMenuComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetCategoriesWithBlogsAsync();
            return View(values);
        }
    }
}
