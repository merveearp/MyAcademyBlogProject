using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.ViewComponents.Admin
{
    public class _AdminHeaderViewComponentPartial:ViewComponent
    {

            protected readonly UserManager<AppUser> _userManager;
            protected readonly SignInManager<AppUser> _signInManager;

        public _AdminHeaderViewComponentPartial(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.User = user.FirstName + " " + user.LastName;
                ViewBag.ProfileImage = user.ImageUrl ?? "/images/default_user.jpg";

                return View();
            }
        
    }
}
