using CleanArchMvc.Domain.Entities.Base;
using CleanArchMvc.Domain.Validation;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; private set; }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid name. Name is required (cannot be a white space)");
            DomainExceptionValidation.When(!Regex.IsMatch(name, @"^[a-zA-Z0-9\s]*$"),
                "Invalid name. Name contains invalid characters.");
            DomainExceptionValidation.When(name.Length > 120,
                $"Invalid name, too long. Maximum of characters: 120. Your name: {name.Length}!");
            DomainExceptionValidation.When(name.Length < 10,
                $"Invalid name, too short. Minimum of characters: 10. Your name: {name.Length}!");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(description),
                "Invalid description. Description is required (cannot be a white space)");
            DomainExceptionValidation.When(DomainExceptionValidation.ValidateInvalidCharacters(description),
                "Invalid description. Description contains invalid characters.");
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
            DomainExceptionValidation.When(categoryId <=  0,
               "Invalid Category. Category is required");
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;

        }
        public Product(string name,string description, decimal price, int categoryId)
        {
            ValidateDomain(name, description, price, 0, null, categoryId);
        }
        public Product(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image, categoryId);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId)
        {
            DomainExceptionValidation.When(Id < 0, "Invalid Id. Id is required");
            Id = id;
            ValidateDomain(name, description, price, stock, image, categoryId);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image, categoryId);
            CategoryId = categoryId;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Name: {Name}");
            stringBuilder.AppendLine($"Identifier: {Id}");
            stringBuilder.AppendLine($"Description: {Description}");
            stringBuilder.AppendLine($"Stock: {Stock}");
            stringBuilder.AppendLine($"Price: {Price.ToString("F2", CultureInfo.InvariantCulture)}");
            stringBuilder.AppendLine($"Category ID: {CategoryId}");
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
