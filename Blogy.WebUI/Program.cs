using Blogy.Business.Extensions;
using Blogy.DataAccess.Extensions;
using Blogy.WebUI.Filters;

var builder = WebApplication.CreateBuilder(args);

//IOC CONTAINER
builder.Services.AddServicesExt();
builder.Services.AddRepositoriesExt(builder.Configuration);


builder.Services.AddControllersWithViews(
    opt =>
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

// Admin Area için route

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

// Writer Area için route
app.MapAreaControllerRoute(
    name: "Writer",
    areaName: "Writer",
    pattern: "Writer/{controller=Home}/{action=Index}/{id?}"
);


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
