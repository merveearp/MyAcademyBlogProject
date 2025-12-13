using AutoMapper;
using Blogy.Business.DTOs.TagDtos;
using Blogy.DataAccess.Repositories.TagRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.TagServices
{
    public class TagService(IMapper _mapper,ITagRepository _tagRepository) : ITagService
    {

        public  async Task CreateAsync(CreateTagDto createDto)
        {
            var value =_mapper.Map<Tag>(createDto);
            await _tagRepository.CreateAsync(value);
            
        }

        public async Task DeleteAsync(int id)
        {
            await _tagRepository.DeleteAsync(id);
        }

        public async Task<List<ResultTagDto>> GetAllAsync()
        {
            var values = await _tagRepository.GetAllAsync();
            return _mapper.Map<List<ResultTagDto>>(values);
            
        }

        public async Task<UpdateTagDto> GetByIdAsync(int id)
        {
            var value = await _tagRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateTagDto>(value);
        }

        public async Task<ResultTagDto> GetSingleByIdAsync(int id)
        {
            var value = await _tagRepository.GetByIdAsync(id);
            return _mapper.Map<ResultTagDto>(value);
        }

        public async Task UpdateAsync(UpdateTagDto updateDto)
        {
            var value = _mapper.Map<Tag>(updateDto);
            await _tagRepository.UpdateAsync(value);
        }
    }
}
