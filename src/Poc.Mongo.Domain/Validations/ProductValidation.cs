using FluentValidation;
using Poc.Mongo.Domain.Entities;

namespace Poc.Mongo.Domain.Validations
{
	public class ProductValidation : AbstractValidator<Product>
	{
		public ProductValidation()
		{
			RuleFor(pr => pr.Name)
				.NotEmpty()
				.WithMessage("Nome é obrigatório.")
				.MaximumLength(200)
				.MinimumLength(3)
				.WithMessage("Nome deve conter entre 3 e 200 caracteres");

			RuleFor(pr => pr.Price)
				.GreaterThan(0)
				.WithMessage("Preço deve ser maior que zero.");

			RuleFor(pr => pr.Category)
				.NotEmpty()
				.WithMessage("Categoria é obrigatória.");

			RuleFor(pr => pr.Description)
				.MaximumLength(200)
				.MinimumLength(5)
				.WithMessage("Descrição deve conter entre 3 e 200 caracteres");
		}
	}
}
