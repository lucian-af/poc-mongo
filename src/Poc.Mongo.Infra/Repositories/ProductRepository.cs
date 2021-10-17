using Poc.Mongo.Domain.Entities;
using Poc.Mongo.Domain.Interfaces;

namespace Poc.Mongo.Infra.Repositories
{
	public class ProductRepository : RepositoryGeneric<Product>, IProductRepository
	{
		public ProductRepository(MongoDbContext context) : base(context) { }
		//=> CatalogContextSeed.SeedData(_collection);
	}
}
