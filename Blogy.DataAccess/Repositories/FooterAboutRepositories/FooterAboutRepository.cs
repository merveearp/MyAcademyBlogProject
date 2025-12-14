using Blogy.DataAccess.Context;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.FooterAboutRepositories
{
    public class FooterAboutRepository : IFooterAboutRepository
    {
        protected readonly AppDbContext _context;

        public FooterAboutRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(FooterAbout footerAbout)
        {
            await _context.FooterAbouts.AddAsync(footerAbout);
            await _context.SaveChangesAsync();
        }

        public async Task<FooterAbout?> GetAsync()
        {
            return await _context.FooterAbouts.FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(FooterAbout footerAbout)
        {
           _context.Update(footerAbout);
            await _context.SaveChangesAsync();
        }
    }
}
