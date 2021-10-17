using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Poc.Mongo.API.Models.Request;
using Poc.Mongo.Domain.Entities;
using Poc.Mongo.Service.Interfaces;

namespace Poc.Mongo.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _serviceProduct;
		private readonly IMapper _mapper;

		public ProductController(
			IProductService serviceProduct,
			IMapper mapper)
		{
			_serviceProduct = serviceProduct;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetProducts()
		{
			var result = await _serviceProduct.GetProducts();

			if (result is null)
				return NotFound();

			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetProduct(string id)
		{
			var result = await _serviceProduct.GetProduct(id);

			if (result is null)
				return NotFound();

			return Ok(result);
		}

		[HttpGet("/category/{category}")]
		public async Task<IActionResult> GetProductByCategory(string category)
		{
			var result = await _serviceProduct.GetProductByCategory(category);

			if (result is null)
				return NotFound();

			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(ProductRequest productRequest)
		{
			var product = _mapper.Map<Product>(productRequest);
			await _serviceProduct.CreateProduct(product);

			return Created("", product);
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(ProductRequest productRequest)
		{
			var product = _mapper.Map<Product>(productRequest);

			await _serviceProduct.UpdateProduct(product);

			return Ok();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteProductById(string id)
		{
			await _serviceProduct.DeleteProductById(id);

			return Ok();
		}
	}
}
