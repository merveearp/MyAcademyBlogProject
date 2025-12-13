using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDto loginDto)
        {
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı Adı veya Şifre Hatalı !");
                return View(loginDto);
            }


            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginDto.UserName);
                var roles = await _userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                {
                    TempData["SuccessMessage"] = "Admin girişi gerçekleştirildi";
                    TempData["UserRole"] = "Admin ";
                    return RedirectToAction("Index", "Default");

                }
                else if (roles.Contains("Writer"))
                {
                    TempData["SuccessMessage"] = "Writer girişi gerçekleştirildi";
                    TempData["UserRole"] = "Writer ";
                    return RedirectToAction("Index", "Default");
                }
                else if (roles.Contains("User"))
                {
                    TempData["SuccessMessage"] = "User girişi gerçekleştirildi";
                    TempData["UserRole"] = "User ";
                    return RedirectToAction("Index", "Default");
                }
            }

            return RedirectToAction("Index", "Default");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Default");
        }
    }
}
