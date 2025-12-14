using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.FooterAboutRepositories
{
    public interface IFooterAboutRepository
    {
        Task<FooterAbout?> GetAsync();
        Task CreateAsync(FooterAbout footerAbout);
        Task UpdateAsync(FooterAbout footerAbout);
    }

}
