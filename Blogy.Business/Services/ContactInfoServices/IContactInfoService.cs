using Blogy.Business.DTOs.ContactInfoDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.ContactInfoServices
{
    public interface IContactInfoService 
    {
        Task<ResultContactInfoDto> GetAsync();
        Task UpdateAsync(UpdateContactInfoDto updateDto);
    }
}
