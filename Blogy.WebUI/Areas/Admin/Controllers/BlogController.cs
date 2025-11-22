using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Framework;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =$"{Roles.Admin}")]

    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }
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

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogsWithCategoriesAsync();
            return View(blogs);
        }

        [HttpGet]
        public async Task<IActionResult> CreateBlog()
        {
            await GetCategoriesAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogDto createBlogDto)
        {
            if(!ModelState.IsValid) 
            {
                await GetCategoriesAsync();
                return View(createBlogDto);
            }

            await _blogService.CreateAsync(createBlogDto);
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBlog(int id)
        {
            await GetCategoriesAsync();
            var blog = await _blogService.GetByIdAsync(id);
            return View(blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogDto updateBlogDto)
        {
            if (!ModelState.IsValid)
            {
                await GetCategoriesAsync();
                return View(updateBlogDto);
            }
            await _blogService.UpdateAsync(updateBlogDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await _blogService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
