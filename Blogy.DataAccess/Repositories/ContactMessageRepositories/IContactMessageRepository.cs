using Blogy.Entity.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.ContactMessageRepositories
{
    public interface IContactMessageRepository 
    {
        Task<List<ContactMessage>> GetAllAsync();
        Task CreateAsync(ContactMessage contactMessage);

    }
}
