using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

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

            var blogs = await _blogService.GetBlogsByCategoryIdAsync(categoryId);
           
            return View(blogs);
        }
    }
}
