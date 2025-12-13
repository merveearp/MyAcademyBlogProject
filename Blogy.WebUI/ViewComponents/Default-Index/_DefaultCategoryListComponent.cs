using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultCategoryListComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategoryListComponent(ICategoryService categoryService)
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
