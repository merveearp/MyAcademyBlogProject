using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.BlogTagServices;
using Microsoft.AspNetCore.Mvc;
using PagedList.Core;

namespace Blogy.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogTagService _blogTagService;
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(int page=1,int pageSize=4)
        {
            var blogs = await _blogService.GetAllAsync();

            var values = new PagedList<ResultBlogDto>(blogs.AsQueryable(), page, pageSize);

            return View(values);
        }
        public async Task<IActionResult> GetBlogsByCategory(int categoryId)
        {

            var blogs = await _blogService.GetBlogsByCategoryIdAsync(categoryId);
           
            return View(blogs);
        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var blog = await _blogService.GetSingleByIdAsync(id);       
            return View(blog);
        }
        
    }
}
