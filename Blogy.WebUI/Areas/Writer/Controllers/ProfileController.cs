using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Writer.Controllers
{

    [Area(Roles.Writer)]
    [Authorize(Roles= Roles.Writer)]
    public class ProfileController(UserManager<AppUser> _userManager,IMapper _mapper) : Controller
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
                //C:\Users\Asus\Desktop\M&Y-YazılımAkademi\MyAcademyBlogProject\Blogy.WebUI bu currentdirectory buluyoruz
                var currentDirectory = Directory.GetCurrentDirectory();

                //Dosyanın Uzantısı .png , .jpeg , ...
                var extensions = Path.GetExtension(editProfileDto.ImageFile.FileName);

                //Guid id+Dosyanın Uzantısı .png ...
                var imageName = Guid.NewGuid() + extensions;

                var saveLocation = Path.Combine(currentDirectory, "wwwroot/images", imageName);

                //akışı kullanırken aç işlem tammalanınca kendşn kapat akışı -- using 
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
    }
}
