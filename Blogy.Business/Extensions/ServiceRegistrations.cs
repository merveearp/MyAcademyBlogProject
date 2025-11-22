using Blogy.Business.Mappings;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Validators.CategoryValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServicesExt(this IServiceCollection Services)
        {

            Services.AddScoped<ICategoryService, CategoryService>();
            Services.AddScoped<IBlogService, BlogService>();
            Services.AddScoped<ICommentService, CommentService>();

            #region AutoMapper

           Services.AddAutoMapper(typeof(CategoryMappings).Assembly);

            #endregion

            #region Validator

           Services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(typeof(CreateCategoryValidator).Assembly);

            #endregion

        }
    }
}
