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
        [Route("{controller}/Index")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductDTO> productDTOs = await _productService.GetProductsAsync();
            return View(productDTOs);
        }
        [HttpGet]
        [Route("{controller}/EditAsync/{id}")]
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
            return View("Index");
        }
        [HttpGet]
        [Route("{controller}/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("{controller}/Created")]
        public async Task<IActionResult> Created(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
                await _productService.Add(product);
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("ErrorInvalidState", "Verifique os campos e tente novamente");
            return View("Create",product);
            
        }
    }
}
