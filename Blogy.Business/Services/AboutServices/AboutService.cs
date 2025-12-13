using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using Blogy.DataAccess.Repositories.AboutRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.AboutServices
{
    public class AboutService(IAboutRepository  _aboutRepository,IMapper _mapper) : IAboutService
    {

        public async Task<ResultAboutDto> GetAsync()
        {
            var value = await _aboutRepository.GetAsync();
            return _mapper.Map<ResultAboutDto>(value);
        }

        public async Task UpdateAsync(UpdateAboutDto updateAboutDto)
        {
           var value =  _mapper.Map<About>(updateAboutDto);
            await _aboutRepository.UpdateAsync(value);
        }
    }
}
