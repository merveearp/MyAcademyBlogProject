using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.User.Controllers
{

    [Area(Roles.User)]
    [Authorize(Roles= Roles.User)]
    public class ProfileController(UserManager<AppUser> _userManager,IMapper _mapper, SignInManager<AppUser> _signInManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var editUser = _mapper.Map<EditProfileDto>(user);
            return View(editUser);
        }

        [HttpPost]
        public async Task<IActionResult> Index(EditProfileDto editProfileDto)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var passwordCorrect = await _userManager.CheckPasswordAsync(user, editProfileDto.CurrentPassword);
            if(!passwordCorrect )
            {
                ModelState.AddModelError("", "Girilen Mevcut Şifreniz Hatalı!");
                return View(editProfileDto);
            }

            if (editProfileDto.ImageFile is not null)
            {
               
                var currentDirectory = Directory.GetCurrentDirectory();              
                var extensions = Path.GetExtension(editProfileDto.ImageFile.FileName);
              
                var imageName = Guid.NewGuid() + extensions;

                var saveLocation = Path.Combine(currentDirectory, "wwwroot/images", imageName);                
                using var stream = new FileStream(saveLocation, FileMode.Create);

                await editProfileDto.ImageFile.CopyToAsync(stream);
                user.ImageUrl = "/images/" + imageName;
            }
                
                user.FirstName = editProfileDto.FirstName;
                user.LastName = editProfileDto.LastName;
                user.Email = editProfileDto.Email;
                user.PhoneNumber = editProfileDto.PhoneNumber;
                user.UserName = editProfileDto.UserName;
                user.Title = editProfileDto.Title;


            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("","Güncelleme esnasında bir hata oluştu!");
                return View(editProfileDto);
            }
            return View(editProfileDto);

        }
       
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            if (!ModelState.IsValid)
                return View(changePasswordDto);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index", "Login");

            var result = await _userManager.ChangePasswordAsync(
                user,
                changePasswordDto.CurrentPassword,
                changePasswordDto.NewPassword
            );

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);

                return View(changePasswordDto);
            }

            TempData["PasswordChanged"] = "Şifreniz başarıyla değiştirildi. Lütfen tekrar giriş yapın.";

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
