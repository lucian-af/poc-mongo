using Poc.Mongo.Models.Interface;

namespace Poc.Mongo.Models.Settings
{
	public abstract class Settings : ISettings
	{
		public override string ToString() => GetType().Name;
	}
}
