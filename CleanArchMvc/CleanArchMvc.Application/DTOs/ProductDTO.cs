﻿using CleanArchMvc.Domain.Entities;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(10)]
        [MaxLength(100)]
        public string Name { get; set; }
        [MinLength(30)]
        [MaxLength(200)]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Stock is required")]
        [Range(1, 9999)]
        public int Stock { get; private set; }
        [MaxLength(250)]
        [DisplayName("Product Image")]
        public string Image { get; private set; }
        [DisplayName("Categories")]
        public int CategoryId { get; private set; }
        public Category Category { get; private set; }
    }
}