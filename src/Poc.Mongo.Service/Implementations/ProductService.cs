using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Poc.Mongo.Core.Exceptions;
using Poc.Mongo.Domain.Entities;
using Poc.Mongo.Domain.Interfaces;
using Poc.Mongo.Service.Interfaces;

namespace Poc.Mongo.Service.Implementations
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repoProduct;

		public ProductService(IProductRepository repoProduct)
			=> _repoProduct = repoProduct;

		public async Task<ICollection<Product>> GetProducts()
		{
			var result = await _repoProduct.GetAll();

			if (result is null)
				return null;

			return result.ToList();
		}

		public async Task<Product> GetProduct(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentException($"Identificador do produto inválido. ParameterName: {nameof(id)}");

			var result = await _repoProduct.GetById(id);

			if (result is null)
				return null;

			return result;
		}

		public async Task<ICollection<Product>> GetProductByCategory(string category)
		{
			if (string.IsNullOrWhiteSpace(category))
				throw new ArgumentException($"Categoria do produto inválida. ParameterName: {nameof(category)}");

			var result = await _repoProduct.GetByFilter(c => c.Category, category);

			if (result is null)
				return null;

			return result.ToList();
		}

		public async Task CreateProduct(Product product)
		{
			var erros = await product.Validar();
			if (!erros.IsValid)
				throw new ArgumentException(string.Join(',', erros.Errors));

			try
			{
				await _repoProduct.Save(product);
			}
			catch
			{
				throw new GenericException("Não foi possível salvar o produto.");
			}
		}

		public async Task<bool> UpdateProduct(Product product)
		{
			var erros = await product.Validar();
			if (!erros.IsValid)
				throw new ArgumentException(string.Join(',', erros.Errors));

			var result = await _repoProduct.Update(product);

			if (!result)
				throw new GenericException("Não foi possível atualizar o produto.");

			return true;
		}

		public async Task<bool> DeleteProductById(string id)
		{
			if (string.IsNullOrWhiteSpace(id))
				throw new ArgumentException($"Identificador do produto inválido. ParameterName: {nameof(id)}");

			var result = await _repoProduct.Delete(id);

			if (!result)
				throw new GenericException("Não foi possível excluir o produto.");

			return true;
		}
	}
}
