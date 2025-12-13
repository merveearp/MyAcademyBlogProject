using AutoMapper;
using Blogy.Business.DTOs.AboutDtos;
using Blogy.Business.DTOs.ContactInfoDtos;
using Blogy.DataAccess.Repositories.ContactInfoRepositories;
using Blogy.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.ContactInfoServices
{
    public class ContactInfoService : IContactInfoService
    {
        private readonly IContactInfoRespository _contactInfoRespository;
        private readonly IMapper _mapper;

        public ContactInfoService(IContactInfoRespository contactInfoRespository, IMapper mapper)
        {
            _contactInfoRespository = contactInfoRespository;
            _mapper = mapper;
        }

        public async Task<ResultContactInfoDto> GetAsync()
        {
            var value = await _contactInfoRespository.GetAsync();
            return _mapper.Map<ResultContactInfoDto>(value);
        }

        public async Task UpdateAsync(UpdateContactInfoDto updateDto)
        {
            var value = _mapper.Map<ContactInfo>(updateDto);
            await _contactInfoRespository.UpdateAsync(value);
        }
    }
}
