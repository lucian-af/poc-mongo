using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Poc.Mongo.Domain.DomainObjects;

namespace Poc.Mongo.Domain.Interfaces
{
	public interface IRepository<T> where T : Base
	{
		Task<T> GetById(string id);
		Task<IEnumerable<T>> GetAll();
		Task<IEnumerable<T>> GetByFilter(Expression<Func<T, object>> expression, object value);
		Task Save(T obj);
		Task<bool> Update(T obj);
		Task<bool> Delete(string id);
	}
}
