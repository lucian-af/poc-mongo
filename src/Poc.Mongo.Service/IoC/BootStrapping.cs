using Microsoft.Extensions.DependencyInjection;
using Poc.Mongo.Domain.Interfaces;
using Poc.Mongo.Infra;
using Poc.Mongo.Infra.Repositories;
using Poc.Mongo.Service.Implementations;
using Poc.Mongo.Service.Interfaces;

namespace Poc.Mongo.Service.IoC
{
	public static class BootStrapping
	{
		public static void ExecuteBootStrapping(this IServiceCollection services)
		{
			// Infra
			services.AddScoped<MongoDbContext>();
			services.AddScoped<IProductRepository, ProductRepository>();

			// Services
			services.AddScoped<IProductService, ProductService>();
		}
	}
}
