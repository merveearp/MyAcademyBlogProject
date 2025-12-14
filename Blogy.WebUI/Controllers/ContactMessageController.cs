using Blogy.Business.DTOs.ContactMessageDtos;
using Blogy.Business.Services.AIServices.ContentService;
using Blogy.Business.Services.ContactMessageServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class ContactMessageController : Controller
    {
        private readonly IContactMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IAIContentService _aIContentService;

        public ContactMessageController(IContactMessageService messageService, UserManager<AppUser> userManager, IAIContentService aIContentService)
        {
            _messageService = messageService;
            _userManager = userManager;
            _aIContentService = aIContentService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateMessage()
        {
            if (User?.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);

                ViewBag.FullName = $"{user.FirstName} {user.LastName}";
                ViewBag.Email = user.Email;
            }

            return View();
        }



        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateContactMessageDto contactMessageDto)
        {
            if (!ModelState.IsValid)
            {
                return View(contactMessageDto);
            }

            var user = await _userManager.GetUserAsync(User);

            contactMessageDto.WriterId = user.Id;
            contactMessageDto.FullName = $"{user.FirstName} {user.LastName}";
            contactMessageDto.Email = user.Email;

            await _messageService.CreateAsync(contactMessageDto);
       
            var aiResponse = await _aIContentService
                .CreateMessageAsync(contactMessageDto.Message);

            TempData["AIResponse"] = aiResponse.Content;

            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi!";

            contactMessageDto.Subject = string.Empty;
            contactMessageDto.Message = string.Empty;

            return View();
        }

    }
}

        
        
