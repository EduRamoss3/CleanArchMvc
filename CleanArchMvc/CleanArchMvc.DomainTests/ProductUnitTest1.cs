using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArchMvc.DomainTests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName ="Create Product With Null Name")]
        public void CreateProduct_WithNullName_ResultObjectInvalidState()
        {
            Action action = () => { Product product = new Product("", "description description", 332, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }
        [Fact(DisplayName ="Create Product Name With Empty Space")]
        public void CreateProduct_WithEmptySpaceInName_ResultObjectInvalidState()
        {
            Action action = () => { Product product = new Product("  ", "description description", 332, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required (cannot be a white space)");
        }
        [Fact(DisplayName ="Create Invalid Product Size Bigger")]
        public void CreateProduct_WithInvalidSize_ResultObjectInvalidState()
        {
            string name = "propropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropropro";
            Action action = () => { Product product = new Product(name, "description description", 322, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage($"Invalid name, too long. Maximum of characters: 120. Your name: {name.Length}!");
        }
        [Fact(DisplayName = "Create Invalid Product Size Small")]
        public void CreateProduct_WithInvalidSizeSmaller_ResultObjectInvalidState()
        {
            string name = "s";
            Action action = () => { Product product = new Product(name, "description description", 322, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage($"Invalid name, too short. Minimum of characters: 10. Your name: {name.Length}!");
        }
    }
}
