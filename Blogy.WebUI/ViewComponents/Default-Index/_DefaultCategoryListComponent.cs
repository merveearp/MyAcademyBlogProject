using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _CategoryListComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryListComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllAsync(); 
            return View(categories);
        }
    }
}
