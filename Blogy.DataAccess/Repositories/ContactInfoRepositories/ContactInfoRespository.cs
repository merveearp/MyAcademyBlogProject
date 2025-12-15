using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.ContactInfoRepositories
{
    public class ContactInfoRespository : IContactInfoRespository
    {
        protected readonly AppDbContext _context;
        public ContactInfoRespository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ContactInfo> GetAsync()
        {
            return await _context.ContactInfos
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(ContactInfo entity)
        {
            var existing = await _context.ContactInfos.FirstOrDefaultAsync();

            if (existing == null)
                return;

            existing.Location = entity.Location;
            existing.OpenHours = entity.OpenHours;
            existing.Email = entity.Email;
            existing.Phone = entity.Phone;

            await _context.SaveChangesAsync();
        }

    }
}
