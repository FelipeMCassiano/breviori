using AutoMapper;
using Breviori.Application.Services.AutoMapper;
using Breviori.Application.UseCases.Url.GetShortenedUrl;
using Breviori.Application.UseCases.Url.RegisterUrl;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Breviori.Application;

public static class DependencyInjectionExtension
{
	public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
	{
		AddUseCases(services);
		AddAutoMapper(services, configuration);
	}

	private static void AddUseCases(IServiceCollection services)
	{
		services.AddScoped<IRegisterUrlUseCase, RegisterUrlUseCase>();
		services.AddScoped<IGetShortenedUrl, GetShortenedUrl>();
	}

	private static void AddAutoMapper(IServiceCollection services, IConfiguration configuration)
	{
		var serverUrl = configuration.GetValue<string>("Settings:ServerUrl");
		services.AddScoped(_ => new MapperConfiguration(config =>
		{
			config.AddProfile(new AutoMapping(serverUrl!));
		}).CreateMapper());
		
	}
}