using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using Poc.Mongo.Domain.DomainObjects;
using Poc.Mongo.Domain.Interfaces;

namespace Poc.Mongo.Infra.Repositories
{
	public abstract class RepositoryGeneric<T> : IRepository<T> where T : Base
	{
		protected MongoDbContext _context;
		protected IMongoCollection<T> _collection;

		public RepositoryGeneric(MongoDbContext context)
		{
			_context = context;
			_collection = _context.DataBase.GetCollection<T>(typeof(T).Name);
		}

		public async Task<T> GetById(string id)
			=> await _collection.Find(c => c.Id.Equals(id)).FirstOrDefaultAsync();

		public async Task<IEnumerable<T>> GetAll()
			=> await _collection.Find(c => true).ToListAsync();

		public async Task<IEnumerable<T>> GetByFilter(Expression<Func<T, object>> expression, object value)
		{
			var filter = Builders<T>.Filter.Eq(expression, value);
			return await _collection.Find(filter).ToListAsync();
		}

		public async Task Save(T obj)
			=> await _collection.InsertOneAsync(obj);

		public async Task<bool> Update(T obj)
		{
			var result = await _collection.ReplaceOneAsync(c => c.Id.Equals(obj.Id), obj);
			return result.IsAcknowledged && result.ModifiedCount > 0;
		}

		public async Task<bool> Delete(string id)
		{
			var filter = Builders<T>.Filter.Eq(p => p.Id, id);
			var result = await _collection.DeleteOneAsync(filter);

			return result.IsAcknowledged && result.DeletedCount > 0;
		}
	}
}
