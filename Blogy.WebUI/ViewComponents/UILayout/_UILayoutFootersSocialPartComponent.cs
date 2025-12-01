using Blogy.Business.Services.SocialServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UILayout
{
    public class _UILayoutFootersSocialPartComponent(ISocialService _socialService) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = _socialService.GetAllAsync();
            return View(values);
        }
    }
}
