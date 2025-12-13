using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.UILayout
{
    public class _UILayoutMenuComponent:ViewComponent
    {
        protected readonly ICategoryService _categoryService;
       
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
