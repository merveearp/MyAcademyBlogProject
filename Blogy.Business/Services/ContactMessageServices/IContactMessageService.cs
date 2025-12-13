using Blogy.Business.DTOs.ContactMessageDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.ContactMessageServices
{
    public interface IContactMessageService
    {
        Task<List<ResultContactMessageDto>> GetAllAsync();
        Task CreateAsync(CreateContactMessageDto createContactMessage);
    }
}
