using MongoDB.Driver;
using Poc.Mongo.Models.Settings;

namespace Poc.Mongo.Infra
{
	public class MongoDbContext
	{
		private MongoClient Client { get; set; }
		public IMongoDatabase DataBase { get; set; }

		public MongoDbContext()
		{
			Client = new MongoClient(MongoDataBaseSettings.Client);
			DataBase = Client.GetDatabase(MongoDataBaseSettings.DataBaseName);
		}
	}
}
