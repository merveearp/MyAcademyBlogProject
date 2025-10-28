using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Blogy.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        


        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
          
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetBlogsByCategory(int categoryId)
        {
            
            var values = await _blogService.GetBlogsByCategoryIdAsync(categoryId);
            ViewBag.CategoryName = values.FirstOrDefault()?.Category?.CategoryName ?? "Kategori bulunamadı";

            return View(values);
        }
    }
}
