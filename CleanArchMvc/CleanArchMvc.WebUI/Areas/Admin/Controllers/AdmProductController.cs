using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdmProductController : Controller
    {
        private readonly IProductService _productService;

        public AdmProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        [Route("{controller}/IndexAsync")]
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<ProductDTO> productDTOs = await _productService.GetProductsAsync();
            return View(productDTOs);
        }
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(int id)
        {
            ProductDTO productDTO = await _productService.GetByIdAsync(id);
            return View(productDTO);
        }
        [HttpPost]
        public async Task<IActionResult> EditAsync(ProductDTO product)
        {
            await _productService.Update(product);
            return View("IndexAsync");
        }
        [HttpGet]
        public IActionResult CreateAsync()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return View("IndexAsync");
            }
            ModelState.AddModelError("ErrorInvalidState", "Verifique os campos e tente novamente");
            return View(product);
            
        }
    }
}
