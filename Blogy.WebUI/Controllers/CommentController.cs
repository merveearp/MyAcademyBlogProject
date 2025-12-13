using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    public class CommentController(ICommentService _commentService , UserManager<AppUser> _userManager,IBlogService _blogService) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> CreateAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateCommentDto createComment)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("BlogDetails", "Blog", new { id = createComment.BlogId });
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            createComment.UserId = user.Id;
            await _commentService.CreateAsync(createComment);

            return RedirectToAction("BlogDetails", "Blog", new { id = createComment.BlogId });
        }


    }
}
