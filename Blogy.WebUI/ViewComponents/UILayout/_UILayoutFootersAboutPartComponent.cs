using Blogy.Business.DTOs.FooterAboutDtos;
using Blogy.DataAccess.Repositories.FooterAboutRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.UILayout
{
    public class _UILayoutFootersAboutPartComponent(IFooterAboutService _footerAboutService) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var footerAbout = await _footerAboutService.GetAsync();
            if (footerAbout == null)
            {
                return View(new ResultFooterAboutDto());
            }

            return View(footerAbout);
        }
    }
}
