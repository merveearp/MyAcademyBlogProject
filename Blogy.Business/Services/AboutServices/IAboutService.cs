using Blogy.Business.DTOs.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AboutServices
{
    public interface IAboutService
    {
        Task<ResultAboutDto> GetAsync();
        Task UpdateAsync(UpdateAboutDto updateAboutDto);
    }
}
