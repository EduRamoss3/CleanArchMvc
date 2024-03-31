using CleanArchMvc.Domain.Entities.Base;
using CleanArchMvc.Domain.Validation;
using System.Text;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0,
               "Invalid Id value. Id is required");
            Id = id;
            ValidateDomain(name);
        }
        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name.Name is required");
            DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name),
                "Invalid name, the name cannot be a white space");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");
            DomainExceptionValidation.When(name.Length > 50, "Invalid name, too long, maximum 50 characters");
            DomainExceptionValidation.When(DomainExceptionValidation.ValidateInvalidCharacters(name),
                "Invalid name. Name contains invalid characters.");
            Name = name;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Name category: {Name}");
            stringBuilder.AppendLine($"Identifier: {Id}");
            return stringBuilder.ToString().ToUpperInvariant();
        }
        public override bool Equals(object obj)
        {
            Category other = obj as Category;
            if (!(obj is Category)) { return false; }
            return Id.Equals(other.Id);
        }
    }
}
