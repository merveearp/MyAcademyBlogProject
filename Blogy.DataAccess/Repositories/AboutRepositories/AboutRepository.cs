using Blogy.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.AboutRepositories
{
    public class AboutRepository : IAboutRepository
    {
        protected readonly AppDbContext _context;

        public AboutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<About> GetAsync()
        {
            return await _context.Abouts.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(About entity)
        {
            _context.Abouts.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
