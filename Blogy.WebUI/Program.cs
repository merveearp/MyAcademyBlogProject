using Blogy.Business.Extensions;
using Blogy.Business.Services.AIServices.CommentDecisionService;
using Blogy.Business.Services.AIServices.ContentService;
using Blogy.Business.Services.AIServices.LanguageService;
using Blogy.Business.Services.AIServices.ToxityService;
using Blogy.Business.Settings;
using Blogy.DataAccess.Extensions;
using Blogy.DataAccess.Repositories.FooterAboutRepositories;
using Blogy.WebUI.Filters;

var builder = WebApplication.CreateBuilder(args);

// IOC
builder.Services.AddServicesExt();

builder.Services.AddRepositoriesExt(builder.Configuration);

builder.Services.Configure<OpenAiSettings>(
    builder.Configuration.GetSection("OpenAI"));

builder.Services.Configure<HuggingFaceSettings>(
    builder.Configuration.GetSection("HuggingFace"));

builder.Services.AddHttpClient<IToxicityService, OpenAIToxicityService>();
builder.Services.AddHttpClient<IAIContentService, AIContentService>();
builder.Services.AddHttpClient<IAILanguageService, AILanguageService>();

builder.Services.AddScoped<IAIDecisionCommentService, AIDecisionCommentService>();
builder.Services.AddScoped<IFooterAboutService, FooterAboutService>();

builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<ValidationExceptionFilter>();
});

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = "/Login/Index";
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// AREAS
app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "Writer",
    areaName: "Writer",
    pattern: "Writer/{controller=Blog}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "User",
    areaName: "User",
    pattern: "User/{controller=Profile}/{action=Index}/{id?}");

// DEFAULT
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
