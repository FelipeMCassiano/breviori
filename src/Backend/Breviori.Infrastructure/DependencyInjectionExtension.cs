using Breviori.Domain.Services.MongoDbService;
using Breviori.Infrastructure.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Breviori.Infrastructure;

public static class DependencyInjectionExtension
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		AddDb(services, configuration);
		
	}

	private static void AddDb(IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<BrevioriDatabaseSettings>(configuration.GetSection("BrevioriDatabase"));
		services.AddSingleton<IMongoDbService, MongoDbService>();
	}
	
}