using System.Threading.Tasks;
using FluentValidation.Results;
using MongoDB.Bson;

namespace Poc.Mongo.Domain.DomainObjects
{
	public abstract class Base
	{
		public Base() => Id = ObjectId.GenerateNewId().ToString();

		public string Id { get; private set; }

		public abstract Task<ValidationResult> Validar();
	}
}
