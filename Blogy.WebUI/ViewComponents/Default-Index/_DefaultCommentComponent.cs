using Blogy.Business.DTOs.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Comment
{
    public class _DefaultCommentComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int blogId)
        {
            ViewBag.BlogId = blogId;
            return View();
        }
    }
}
