using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Poc.Mongo.Domain.Entities;

namespace Poc.Mongo.Infra.Seed
{
	public static class CatalogContextSeed
	{

		public static void SeedData(IMongoCollection<Product> productColletion)
		{
			if (!productColletion.Find(p => true).Any())
				productColletion.InsertMany(GetMyProducts());
		}


		public static IEnumerable<Product> GetMyProducts()
		 => new List<Product>
		 {
			 new Product(

				 "SAMSUNG S20",
				 "SMARTPHONE",
				 "SMARTPHONE SAMSUNG S20 C/ 9 CÂMERAS",
				 null,
				 8999.0m
			 )
		 };
	}
}
