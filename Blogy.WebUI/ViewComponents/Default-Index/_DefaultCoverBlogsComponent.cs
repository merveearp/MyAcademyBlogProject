using Blogy.Business.Services.BlogServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultCoverBlogsComponent:ViewComponent
    {
        private readonly IBlogService _blogService;

        public _DefaultCoverBlogsComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _blogService.GetAllAsync();
            return View(values);
        }
    }
}
