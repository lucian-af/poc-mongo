using System.Collections.Generic;
using System.Threading.Tasks;
using Poc.Mongo.Domain.Entities;

namespace Poc.Mongo.Service.Interfaces
{
	public interface IProductService
	{
		Task<ICollection<Product>> GetProducts();
		Task<Product> GetProduct(string id);
		Task<ICollection<Product>> GetProductByCategory(string category);
		Task CreateProduct(Product product);
		Task<bool> UpdateProduct(Product product);
		Task<bool> DeleteProductById(string id);
	}
}
