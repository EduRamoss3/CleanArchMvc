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

        public async Task Add(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            await _productRepository.CreateAsync(entity);
        }

        public async Task<ProductDTO> GetByIdAsync(int? id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> GetProductCategoryAsync(int? id)
        {
            var entity = await _productRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(entity);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
            var entity = await _productRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(entity);
        }

        public async Task Remove(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            await _productRepository.RemoveAsync(entity);
        }

        public async Task Update(ProductDTO product)
        {
            var entity = _mapper.Map<Product>(product);
            await _productRepository.UpdateAsync(entity);   
        }
    }
}
