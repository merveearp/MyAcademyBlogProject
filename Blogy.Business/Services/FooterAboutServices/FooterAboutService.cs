using AutoMapper;
using Blogy.Business.DTOs.FooterAboutDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.FooterAboutRepositories
{
    public class FooterAboutService(IFooterAboutRepository _aboutRepository,IMapper _mapper) : IFooterAboutService
    {

        public async Task CreateAsync(CreateFooterAboutDto footerAbout)
        {
            var value = _mapper.Map<FooterAbout>(footerAbout);
            await _aboutRepository.CreateAsync(value);
        }

        public async Task<ResultFooterAboutDto?> GetAsync()
        {
            var value =  await _aboutRepository.GetAsync();
            return _mapper.Map<ResultFooterAboutDto>(value);
        }

        public Task UpdateAsync(UpdateFooterAboutDto footerAbout)
        {
            var value = _mapper.Map<FooterAbout>(footerAbout);
            return _aboutRepository.UpdateAsync(value);
        }
    }
}
