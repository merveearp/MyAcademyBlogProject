using Blogy.Business.Mappings;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Validators.CategoryValidators;
using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.DataAccess.Repositories.BlogTagRepositories;
using Blogy.DataAccess.Repositories.CategoryRepositories;
using Blogy.DataAccess.Repositories.SocialRepositories;
using Blogy.DataAccess.Repositories.TagRepositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


#region AutoMapper

builder.Services.AddAutoMapper(typeof(CategoryMappings).Assembly);

#endregion

#region Validator

builder.Services
    .AddFluentValidationAutoValidation()
    .AddFluentValidationClientsideAdapters()
    .AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly);
    

#endregion

#region Category Repository ve Service

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService,CategoryService>();

#endregion

#region Blog Repository ve Service

builder.Services.AddScoped<IBlogService,BlogService>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();

#endregion

#region BlogTag Repository ve Service

builder.Services.AddScoped<IBlogTagRepository, BlogTagRepository>();

#endregion

#region Tag Repository ve Service

builder.Services.AddScoped<ITagRepository, TagRepository>();

#endregion

#region Social Repository ve Service

builder.Services.AddScoped<ISocialRepository, SocialRepository>();

#endregion


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
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
 