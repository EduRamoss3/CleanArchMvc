using CleanArchMvc.Domain.Entities.Base;
using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is required (cannot be a white space)");
            DomainExceptionValidation.When(Name.Length > 120,
                $"Invalid name, too long. Maximum of characters: 120. Your name: {name.Length}!");
            DomainExceptionValidation.When(Name.Length < 10,
                $"Invalid name, too short. Minimum of characters: 10. Your name: {name.Length}!");
            DomainExceptionValidation.When(DomainExceptionValidation.ValidateInvalidCharacters(name),
                "Invalid name. Name contains invalid characters.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
                "Invalid description. Description is required (cannot be a white space)");
            DomainExceptionValidation.When(description.Length > 200,
                $"Invalid description, too long. Maximum of characters: 200. Characters in your description: {description.Length}!");
            DomainExceptionValidation.When(description.Length < 30,
                $"Invalid description, too short. Minimum of characters: 30. Characters in your description: {description.Length}!");
            DomainExceptionValidation.When(price < 0,
                "Invalid price. Price is required");
            DomainExceptionValidation.When(price > 9999,
                "Invalid price. Too long.");
            DomainExceptionValidation.When(stock < 0,
                "Invalid stock. Stock is required");
            DomainExceptionValidation.When(image.Length > 250,
                $"Invalid url image. The maximum of characters is 250. Your url: {image.Length}!");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;     
        }
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(Id < 0, "Invalid Id. Id is required");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Identifier: {Id}");
            stringBuilder.AppendLine($"Description: {Description}");
            stringBuilder.AppendLine($"Stock: {Stock}");
            stringBuilder.AppendLine($"Price: {Price.ToString("F2",CultureInfo.InvariantCulture)}");
            return stringBuilder.ToString().ToUpperInvariant();
        }
        public override bool Equals(object obj)
        {
            Product other = obj as Product;
            if (!(obj is Product)) { return false; }
            return Name.Equals(other.Name);
        }
    }
}
