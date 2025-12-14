using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.TagServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Writer.Controllers
{
    [Area(Roles.Writer)]
    [Authorize(Roles = Roles.Writer)]
    public class BlogController(IBlogService _blogService,UserManager<AppUser> _userManager ,ICategoryService _categoryService,ITagService _tagService) : Controller
    {
        private async Task GetCategoriesAsync()
        {
            var categories = await _categoryService.GetAllAsync();
            ViewBag.Categories = (from category in categories
                                  select new SelectListItem
                                  {
                                      Text = category.CategoryName,
                                      Value = category.Id.ToString()
                                  }).ToList();
        }
        private async Task GetTagsAsync()
        {
            var tags = await _tagService.GetAllAsync();
            ViewBag.Tags = (from tag in tags
                            select new SelectListItem
                            {
                                Text = tag.Name,
                                Value = tag.Id.ToString()
                            }).ToList();
        }

        public async Task<IActionResult> Index()
        {
            var userBlogs = await _userManager.FindByIdAsync(User.Identity.Name);
            var blogs = await _blogService.GetAllAsync();
            return View();
        }

        //yenimetot yaz repository service getuserıdblog metodu 


    }
}
