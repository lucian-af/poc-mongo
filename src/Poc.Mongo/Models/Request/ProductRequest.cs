namespace Poc.Mongo.API.Models.Request
{
	public class ProductRequest
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		public string Description { get; set; }
		public string Image { get; set; }
		public decimal Price { get; set; }
	}
}
