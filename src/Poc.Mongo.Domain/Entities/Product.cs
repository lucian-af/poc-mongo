using System.Threading.Tasks;
using FluentValidation.Results;
using Poc.Mongo.Domain.DomainObjects;
using Poc.Mongo.Domain.Validations;

namespace Poc.Mongo.Domain.Entities
{
	public class Product : Base
	{
		public Product(
			string name,
			string category,
			string description,
			string image,
			decimal price) : base()
		{
			Name = name;
			Category = category;
			Description = description;
			Image = image;
			Price = price;
		}

		public string Name { get; private set; }
		public string Category { get; private set; }
		public string Description { get; private set; }
		public string Image { get; private set; }
		public decimal Price { get; private set; }

		public void UpdateName(string newName)
			=> Name = newName;

		public void UpdatePrice(decimal newPrice)
			=> Price = newPrice;

		public void UpdateImage(string newImage)
			=> Image = newImage;

		public void UpdateDescription(string newDescription)
			=> Description = newDescription;

		public void UpdateCategory(string newCategory)
			=> Category = newCategory;

		public override Task<ValidationResult> Validar()
			=> new ProductValidation().ValidateAsync(this);
	}
}
