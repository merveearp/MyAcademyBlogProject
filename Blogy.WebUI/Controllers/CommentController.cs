using Blogy.Business.DTOs.CommentDtos;
using Blogy.Business.Services.AIServices.CommentDecisionService;
using Blogy.Business.Services.AIServices.LanguageService;
using Blogy.Business.Services.AIServices.ToxityService;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Entity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Blogy.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        private readonly UserManager<AppUser> _userManager;

        private readonly IBlogService _blogService;

        private readonly IAILanguageService _aiLanguageService;
        private readonly IToxicityService _toxicityService;
        private readonly IAIDecisionCommentService _aiDecisionCommentService;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager, IBlogService blogService, IToxicityService toxicityService, IAIDecisionCommentService aiDecisionCommentService, IAILanguageService aiLanguageService)
        {
            _commentService = commentService;
            _userManager = userManager;
            _blogService = blogService;

            _toxicityService = toxicityService;
            _aiDecisionCommentService = aiDecisionCommentService;
            _aiLanguageService = aiLanguageService;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentDto createComment)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("BlogDetails", "Blog",
                    new { id = createComment.BlogId });
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            createComment.UserId = user.Id;
            ViewBag.ImageUrl = user.ImageUrl;

            string contentForAI = createComment.Content;

            try
            {
                var translated = await _aiLanguageService.TranslateAsync(createComment.Content);
                contentForAI = translated ?? createComment.Content;
            }
            catch
            {
                TempData["ToxicComment"] =
                    "Yorumunuz şu anda değerlendirilemedi. Lütfen daha sonra tekrar deneyin.";

                return RedirectToAction("BlogDetails", "Blog",
                    new { id = createComment.BlogId });
            }

            double toxicityScore;

            try
            {
                toxicityScore = await _toxicityService.GetToxicityScoreAsync(contentForAI);
            }
            catch
            {
                TempData["ToxicComment"] =
                    "Yorumunuz güvenlik kontrolünden geçirilemedi.";

                return RedirectToAction("BlogDetails", "Blog",
                    new { id = createComment.BlogId });
            }

            var isApproved = await _aiDecisionCommentService.DecisionAsync(toxicityScore);

            if (!isApproved)
            {
                TempData["ToxicComment"] =
                    "Yorumunuz hakaret veya uygunsuz dil içerdiği için yayınlanmadı.";

                return RedirectToAction("BlogDetails", "Blog",
                    new { id = createComment.BlogId });
            }

            await _commentService.CreateAsync(createComment);

            return RedirectToAction("BlogDetails", "Blog",
                new { id = createComment.BlogId });
        }



    }
}
