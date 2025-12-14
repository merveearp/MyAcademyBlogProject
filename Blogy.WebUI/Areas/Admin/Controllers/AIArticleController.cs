using Blogy.Business.DTOs.AIDtos;
using Blogy.Business.Services.AIServices.ContentService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AIArticleController : Controller
    {
        private readonly IAIContentService _aiContentService;

        public AIArticleController(IAIContentService aiContentService)
        {
            _aiContentService = aiContentService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAIArticleDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Keyword))
            {
                ModelState.AddModelError("", "Anahtar kelime boş olamaz.");
                return View(dto);
            }

            var result = await _aiContentService.CreateArticleAsync(dto);

            ViewBag.GeneratedArticle = result.Content;

            return View(dto);
        }
    }
}
