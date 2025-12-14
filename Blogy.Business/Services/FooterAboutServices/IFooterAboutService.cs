using Blogy.Business.DTOs.FooterAboutDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.FooterAboutRepositories
{
    public interface IFooterAboutService
    {
        Task<ResultFooterAboutDto?> GetAsync();
        Task CreateAsync(CreateFooterAboutDto footerAbout);
        Task UpdateAsync(UpdateFooterAboutDto footerAbout);
    }
}
