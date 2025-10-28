using Blogy.Business.Extensions;
using Blogy.DataAccess.Extensions;

var builder = WebApplication.CreateBuilder(args);

//IOC CONTAINER
builder.Services.AddServicesExt();
builder.Services.AddRepositoriesExt(builder.Configuration);


builder.Services.AddControllersWithViews();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
   
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
 