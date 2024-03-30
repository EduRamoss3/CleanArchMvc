using CleanArchMvc.Domain.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace CleanArchMvc.DomainTests
{
    
    public class CategoryUnitTest1
    {
        [Fact(DisplayName ="Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();   
        }
        [Fact(DisplayName = "Create Category With Invalid State")]
        public void CreateCategory_WithInvalidParameters_ResultObjectInvalidState()
        {
            Action action = () => new Category(1,"");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name.Name is required");
        }
        [Fact(DisplayName = "Create Category With Empty space")]
        public void CreateCategory_WithInvalidParameters_ResultObjectInvalidObjectEmptySpace()
        {
            Action action = () => new Category(1, "   ");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name, the name cannot be a white space");
        }
        [Fact(DisplayName ="Create Category With Invalid Characters")]
        public void CreateCategory_WithInvalidCharacters_ResultObjectInvalidObjectInvalidCharacters()
        {
            Action action = () => new Category(1, "@categor$5¨¨");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name contains invalid characters.");
        }
        [Fact(DisplayName = "Create Category With Valid Characters")]
        public void CreateCategory_WithValidCharacters_ResultObjectNotInvalidCharacters()
        {
            Action action = () => new Category(1, "nome da categoria");
            action.Should().NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
    }
}
