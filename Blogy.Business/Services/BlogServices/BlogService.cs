using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.BlogRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.BlogServices
{
    public class BlogService : IBlogService
    {
        private readonly IMapper _mapper;
        private readonly IBlogRepository _blogRepository;

        public BlogService(IMapper mapper, IBlogRepository blogRepository)
        {
            _mapper = mapper;
            _blogRepository = blogRepository;
        }

        public async Task CreateAsync(CreateBlogDto createDto)
        {
            var entity = _mapper.Map<Blog>(createDto);

            await _blogRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _blogRepository.DeleteAsync(id);
        }

        public async Task<List<ResultBlogDto>> GetAllAsync()
        {
            var values = await _blogRepository.GetAllWithTagsAsync();
            return _mapper.Map<List<ResultBlogDto>>(values);
        }



        public async Task<List<ResultBlogDto>> GetBlogsByCategoryIdAsync(int categoryId)
        {
            var entities = await _blogRepository.GetBlogsByCategoryIdAsync(categoryId);
            return _mapper.Map<List<ResultBlogDto>>(entities);
        }

        public async Task<List<ResultBlogDto>> GetBlogsByWriterIdAsync(int writerId)
        {
            var entities = await _blogRepository.GetBlogsByWriterIdAsync(writerId);

            return _mapper.Map<List<ResultBlogDto>>(entities);
        }

        public async Task<List<ResultBlogDto>> GetBlogsWithCategoriesAsync()
        {
            var values = await _blogRepository.GetBlogsWithCategoriesAsync();
            return _mapper.Map<List<ResultBlogDto>>(values);
        }

        public async Task<UpdateBlogDto> GetByIdAsync(int id)
        {
            var entity = await _blogRepository.GetByIdAsync(id);
            return _mapper.Map<UpdateBlogDto>(entity);
        }


        public async Task<List<ResultBlogDto>> GetLast3BlogsAsync()
        {
           var entities = await _blogRepository.GetLast3BlogsAsync();
            return _mapper.Map<List<ResultBlogDto>>(entities);
        }

        public async Task<ResultBlogDto> GetSingleByIdAsync(int id)
        {
            var entity = await _blogRepository.GetByIdAsync(id);
            return _mapper.Map<ResultBlogDto>(entity);
        }

        public async Task UpdateAsync(UpdateBlogDto updateDto)
        {
            var entity = _mapper.Map<Blog>(updateDto);
            await _blogRepository.UpdateAsync(entity);
        }
    }
}
