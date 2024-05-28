using AutoMapper;
using CleanArchMvc.Application.Categories.Commands;
using CleanArchMvc.Application.Categories.Queries;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class CategoryServices : ICategoryService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CategoryServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;   
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            GetCategoriesQuery categoriesQuery = new GetCategoriesQuery();
            var categoriesEntity = await _mediator.Send(categoriesQuery);

            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            GetCategoryByIdQuery getCategoryByIdQuery = new GetCategoryByIdQuery(id.Value);

            var categoryEntity = await _mediator.Send(getCategoryByIdQuery);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public async Task Add(CategoryDTO categoryDTO)
        {
            CategoryCreateCommand categoryCreateCommand = _mapper.Map<CategoryCreateCommand>(categoryDTO);
            await _mediator.Send(categoryCreateCommand);      
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            CategoryUpdateCommand categoryUpdateCommand = _mapper.Map<CategoryUpdateCommand>(categoryDTO);
            await _mediator.Send(categoryUpdateCommand);
        }

        public async Task Remove(int? id)
        {
            CategoryRemoveCommand categoryRemoveCommand = new(id.Value);
            await _mediator.Send(categoryRemoveCommand);
        }
    }
}
