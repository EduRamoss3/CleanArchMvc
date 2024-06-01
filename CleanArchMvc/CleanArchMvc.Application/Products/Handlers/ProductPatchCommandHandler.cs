using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductPatchCommandHandler : IRequestHandler<ProductPatchCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductPatchCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductPatchCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if(product is Product)
            {
                product.UpdateName(request.Name);
                await _productRepository.PatchNameAsync(product);
            }
            throw new ApplicationException("Error in update name");
        }
    }
}
