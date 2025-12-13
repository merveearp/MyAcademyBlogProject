using Blogy.Business.Services.ContactMessageServices;
using Blogy.WebUI.Consts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = $"{Roles.Admin}")]
    public class ContactMessageController(IContactMessageService _messageService) : Controller
    {
       
        public async Task<IActionResult> Index()
        {
            var values = await _messageService.GetAllAsync();
            return View(values);
        }
    }
}
