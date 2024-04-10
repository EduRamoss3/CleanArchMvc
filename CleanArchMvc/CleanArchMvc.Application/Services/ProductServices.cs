using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{

    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> CreateAsync(ProductDTO product)
        {

            var entity = _mapper.Map<Product>(product);
            await _productRepository.CreateAsync(entity);
            return entity;
        }

        public Task<Product> GetByIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductCategoryAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> RemoveAsync(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public Task<Product> UpdateAsync(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
