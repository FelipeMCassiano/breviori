using Breviori.Domain.Services.MongoDbService;

namespace Breviori.Application.UseCases.Url.DeleteShortenedUrl;

public class DeleteShortenedUrl: IDeleteShortenedUrl 
{
	private readonly IMongoDbService _mongoDbService;

	public DeleteShortenedUrl(IMongoDbService mongoDbService)
	{
		_mongoDbService = mongoDbService;
	}

	public async Task Execute(string url)
	{
		await _mongoDbService.DeleteUrlAsync(url);
	}
}