using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Domain.Entities;

namespace CleanArchMvc.WebUI.ViewModel
{
    public class CreateProductViewModel
    {
        public ProductDTO Product { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
