using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.WebUI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdmProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdmProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
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
        public async Task<IActionResult> Create()
        {
            CreateProductViewModel createProductViewModel = new CreateProductViewModel()
            {
                Categories = await _categoryService.GetCategories()
            };
            return View(createProductViewModel);
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
            CreateProductViewModel createProductViewModel = new CreateProductViewModel()
            {
                Product = product,
                Categories = await _categoryService.GetCategories()
            };

            ModelState.AddModelError("ErrorInvalidState", "Verifique os campos e tente novamente");
            return View("Create", createProductViewModel);
            
        }
    }
}
