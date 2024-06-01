using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{

    public class ProductServices : IProductService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductServices(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(ProductDTO product)
        {
            var productCreateCommand = _mapper.Map<ProductCreateCommand>(product);
            await _mediator.Send(productCreateCommand);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var getProductByIdQuery = new GetProductByIdQuery(id.Value);
            var result = await _mediator.Send(getProductByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var getProductByIdQuery = new GetProductByIdQuery(id.Value);
            var result = await _mediator.Send(getProductByIdQuery);
            return _mapper.Map<ProductDTO>(result);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var productsQuery = new GetProductsQuery();
            if(productsQuery is null)
            {
                throw new ApplicationException($"Entity coul not be loaded");
            }
            var result = await _mediator.Send(productsQuery);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);
        }

        public async Task PatchName(string name, int id)
        {
            var productPatchCommand = new ProductPatchCommand(id, name);
            if (productPatchCommand is null)
            {
                throw new ApplicationException($"Entity coul not be loaded");
            }
             await _mediator.Send(productPatchCommand);
        }

        public async Task Remove(ProductDTO product)
        {
            var productRemoveCommand = new ProductRemoveCommand(product.Id);
            if(productRemoveCommand is null)
            {
                throw new Exception($"Entity could not be loaded");
            }
            await _mediator.Send(productRemoveCommand);
        }

        public async Task Update(ProductDTO product)
        {
            var productUpdateCommand = _mapper.Map<ProductUpdateCommand>(product);
            await _mediator.Send(productUpdateCommand);
        }
    }
}
