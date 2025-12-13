using Blogy.Business.Services.ContactInfoServices;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.ViewComponents.Default_Index
{
    public class _DefaultContactInfoComponent(IContactInfoService _contactInfoService) :ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _contactInfoService.GetAsync();
            return View(values);
        }
    }
}
