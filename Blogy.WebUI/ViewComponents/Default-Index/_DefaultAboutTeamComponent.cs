using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blogy.WebUI.ViewComponents.About_Team
{
    public class _DefaultAboutTeamComponent : ViewComponent
    {
        protected readonly UserManager<AppUser> _userManager;

        public _DefaultAboutTeamComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _userManager.Users.ToListAsync();

            var list = new List<AppUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin") || roles.Contains("Writer"))
                {
                    list.Add(user);
                }
            }

            return View(list);
        }
    }
}
