using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Task<CategoryDTO> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Add(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task Update(CategoryDTO categoryDTO)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
