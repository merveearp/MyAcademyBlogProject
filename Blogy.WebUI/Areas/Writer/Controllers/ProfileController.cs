using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Writer.Controllers
{

    [Area(Roles.Writer)]
    [Authorize(Roles= Roles.Writer)]
    public class ProfileController(UserManager<AppUser> _userManager,IMapper _mapper, SignInManager<AppUser> _signInManager) : Controller
    {
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Index", "Login");

            var editUser = _mapper.Map<EditProfileDto>(user);
            return View(editUser);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Index(EditProfileDto editProfileDto)
        {
            if (!ModelState.IsValid)
                return View(editProfileDto);

            var user = await _userManager.GetUserAsync(User);
           
            var passwordCorrect = await _userManager.CheckPasswordAsync(
                user, editProfileDto.CurrentPassword);

            if (!passwordCorrect)
            {
                ModelState.AddModelError("", "Girilen mevcut şifreniz hatalı!");
                return View(editProfileDto);
            }

            if (editProfileDto.ImageFile is not null)
            {
                var extension = Path.GetExtension(editProfileDto.ImageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var savePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images",
                    imageName);

                using var stream = new FileStream(savePath, FileMode.Create);
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
                ModelState.AddModelError("", "Güncelleme sırasında bir hata oluştu.");
                return View(editProfileDto);
            }

            TempData["ProfileUpdated"] = "Profil bilgileriniz başarıyla güncellendi.";
            return RedirectToAction("Index");
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
