using Blogy.Business.Mappings;
using Blogy.Business.Services.BlogServices;
using Blogy.Business.Services.CategoryServices;
using Blogy.Business.Services.CommentServices;
using Blogy.Business.Validators.CategoryValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddServicesExt(this IServiceCollection Services)
        {
            Services.Scan(opt =>
            {
                opt.FromAssemblies(Assembly.GetExecutingAssembly())
                    .AddClasses(publicOnly: false)
                    .UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip)
                    .AsMatchingInterface()
                    .AsImplementedInterfaces()
                    .WithScopedLifetime();
            });

            #region AutoMapper

            Services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #endregion

            #region Validator

           Services
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            #endregion

        }
    }
}
