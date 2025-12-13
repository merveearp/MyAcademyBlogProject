using Blogy.DataAccess.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.AboutRepositories
{
    public interface IAboutRepository 
    {
        Task<About> GetAsync();
        Task UpdateAsync(About about);
    }
}
