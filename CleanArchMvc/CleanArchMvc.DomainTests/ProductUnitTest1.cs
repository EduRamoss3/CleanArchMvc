using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.DomainTests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product With Null Name")]
        public void CreateProduct_WithNullName_ResultObjectInvalidState()
        {
            Action action = () => { Product product = new Product("", "description description", 332, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
        }
        [Fact(DisplayName = "Create Product Name With Empty Space")]
        public void CreateProduct_WithEmptySpaceInName_ResultObjectInvalidState()
        {
            Action action = () => { Product product = new Product("  ", "description description", 332, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid name. Name is required (cannot be a white space)");
        }
        [Fact(DisplayName = "Create Invalid Product Size Bigger")]
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
        [Fact(DisplayName = "Create Invalid Product Description Size Small")]
        public void CreateProduct_WithInvalidDescriptionSizeSmaller_ResultObjectInvalidState()
        {
            string description = "desc";
            Action action = () => { Product product = new Product("Product Name", description, 332, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage($"Invalid description, too short. Minimum of characters: 30. Characters in your description: {description.Length}!");
        }

        [Fact(DisplayName = "Create Invalid Price")]
        public void CreateProduct_WithInvalidPrice_ResultObjectInvalidState()
        {
            Action action = () => { Product product = new Product("Product Name", "Uma descrição sobre um produto em teste no qual estou usando xUnit para testes unitários", -1, 2, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid price. Price is required");
        }

        [Fact(DisplayName = "Create Invalid Stock")]
        public void CreateProduct_WithInvalidStock_ResultObjectInvalidState()
        {
            Action action = () => { Product product = new Product("Product Name", "Uma descrição sobre um produto em teste no qual estou usando xUnit para testes unitários", 332, -1, null); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Invalid stock. Stock is required");
        }

        [Fact(DisplayName = "Create Invalid Image Size")]
        public void CreateProduct_WithInvalidImageSize_ResultObjectInvalidState()
        {
            string image = "image".PadRight(251, 'x');
            Action action = () => { Product product = new Product("Product Name", "Uma descrição sobre um produto em teste no qual estou usando xUnit para testes unitários", 332, 2, image); };
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>().WithMessage($"Invalid url image. The maximum of characters is 250. Your url: {image.Length}!");
        }

    }
}
