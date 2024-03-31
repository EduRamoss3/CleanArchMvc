using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;


namespace CleanArchMvc.Application.Services
{
    public class CategoryServices : ICategoryService
    {
        private ICategoryRepository _categoryReposity;
        private readonly IMapper _mapper;
        public CategoryServices(ICategoryRepository categoryReposity, IMapper mapper)
        {
            _categoryReposity = categoryReposity;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryReposity.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoryEntity = await _categoryReposity.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            var categoryToCategoryDTO = _mapper.Map<Category>(categoryDTO);
            await _categoryReposity.CreateAsync(categoryToCategoryDTO);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var categoryToCategoryDTO = _mapper.Map<Category>(categoryDTO);
            await _categoryReposity.UpdateAsync(categoryToCategoryDTO);
        }

        public async Task Remove(int? id)
        {
            var category = await _categoryReposity.GetByIdAsync(id);
            await _categoryReposity.RemoveAsync(category);
        }
    }
}
