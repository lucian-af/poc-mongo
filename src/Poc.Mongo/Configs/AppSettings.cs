using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Poc.Mongo.Models.Interface;
using Poc.Mongo.Models.Settings;

namespace Poc.Mongo.API.Configs
{
	public static class AppSettings
	{
		public static void LoadSettings(this IServiceCollection services, IConfiguration configuration)
		{
			var settings = new List<ISettings>
			{
				new MongoDataBaseSettings()
			};

			settings.ForEach(s =>
			{
				configuration.Bind(s.ToString(), s);
				services.AddSingleton(s.GetType(), s);
			});
		}
	}
}
