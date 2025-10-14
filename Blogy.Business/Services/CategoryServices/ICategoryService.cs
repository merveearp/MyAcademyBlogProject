using Blogy.Business.DTOS.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllAsync();
        Task<List<ResultCategoryDto>> GetCategoriesWithBlogsAsync();
        Task<UpdateCategoryDto> GetByIdAsync(int id);
        Task DeleteAsync(int id );
        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
        Task CreateAsync(CreateCategoryDto createCategoryDto);

    }
}
