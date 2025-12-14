using Blogy.Business.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class CategoryController(ICategoryService _categoryService) : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllAsync();
            return View(categories);
        }
    }
}
