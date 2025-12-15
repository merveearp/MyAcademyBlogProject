using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.BlogTagServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Services.TagServices;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Roles.Admin)]
    public class HomeController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITagService _tagService;
        private readonly IBlogTagService _blogTagService;

        public HomeController(
            IBlogService blogService,
            ICategoryService categoryService,
            ICommentService commentService,
            UserManager<AppUser> userManager,
            ITagService tagService,
            IBlogTagService blogTagService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _commentService = commentService;
            _userManager = userManager;
            _tagService = tagService;
            _blogTagService = blogTagService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();
            var comments = await _commentService.GetAllAsync();

            // Statistic Cards
            ViewBag.BlogCount = blogs.Count();
            ViewBag.CategoryCount = categories.Count();
            ViewBag.CommentCount = comments.Count();
            ViewBag.UserCount = _userManager.Users.Count();

            // Chart 1 – Category / Blog
            ViewBag.CategoryNames = categories
                .Select(c => c.CategoryName) 
                .ToList();

            ViewBag.CategoryBlogCounts = categories
                .Select(c => blogs.Count(b => b.CategoryId == c.Id))
                .ToList();

            // Chart 2 – Blog / Comment
            ViewBag.BlogTitles = blogs
                .Select(b => b.Title)
                .ToList();

            ViewBag.BlogCommentCounts = blogs
                .Select(b => comments.Count(c => c.BlogId == b.Id))
                .ToList();

            // Widget – Last 3 Blogs
            ViewBag.LastBlogs = await _blogService.GetLast3BlogsAsync();

            var tags = await _tagService.GetAllAsync();
            var blogTags = await _blogTagService.GetAllAsync();

            // Chart 3 – Tag isimleri
            ViewBag.TagNames = tags
                .Select(t => t.Name)
                .ToList();

            // Chart 3 – Tag başına blog sayısı
            ViewBag.TagBlogCounts = tags
                .Select(t => blogTags.Count(bt => bt.TagId == t.Id))
                .ToList();


            return View();
        }
    }
}
