using Blogy.DataAccess.Context;
using Blogy.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.ContactMessageRepositories
{
    public class ContactMessageRepository : IContactMessageRepository        
    {

        protected readonly AppDbContext _context;
       
        public ContactMessageRepository(AppDbContext context)
        {
            _context = context;
           
        }

        public async Task CreateAsync(ContactMessage contactMessage)
        {
            await _context.AddAsync(contactMessage);
            await _context.SaveChangesAsync();
        }

        public async Task<List<ContactMessage>> GetAllAsync()
        {
            return await _context.ContactMessages.AsNoTracking().ToListAsync();
        }
    }
}