using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.ViewComponents.UILayout
{
    public class _UILayoutWriterMenuComponent : ViewComponent
    {
        protected readonly ICategoryService _categoryService;
        protected readonly UserManager<AppUser> _userManager;
        protected readonly SignInManager<AppUser> _signInManager;

        public _UILayoutWriterMenuComponent(ICategoryService categoryService, UserManager<AppUser> userManager = null, SignInManager<AppUser> signInManager = null)
        {
            _categoryService = categoryService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.User = user.FirstName + " " + user.LastName;
            ViewBag.ProfileImage = user.ImageUrl ?? "/images/default_user.jpg";

            var values = await _categoryService.GetCategoriesWithBlogsAsync();

            return View(values);
        }
    }
}
