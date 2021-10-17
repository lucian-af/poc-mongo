using AutoMapper;
using Poc.Mongo.API.Models.Request;
using Poc.Mongo.Domain.Entities;

namespace Poc.Mongo.API.Configs
{
	public class AutoMapperConfig : Profile
	{
		public AutoMapperConfig()
		=> CreateMap<ProductRequest, Product>()
			.ConstructUsing(c => new Product(
				c.Name,
				c.Category,
				c.Description,
				c.Image,
				c.Price)
			).ForMember(c => c.Id, d => d.Condition(s => !string.IsNullOrWhiteSpace(s.Id)));
	}
}
