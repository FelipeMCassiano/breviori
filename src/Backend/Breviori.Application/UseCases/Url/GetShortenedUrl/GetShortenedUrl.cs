using Breviori.Domain.Services.MongoDbService;

namespace Breviori.Application.UseCases.Url.GetShortenedUrl;

public class GetShortenedUrl: IGetShortenedUrl
{
	private readonly IMongoDbService _mongoDbService;

	public GetShortenedUrl(IMongoDbService mongoDbService)
	{
		_mongoDbService = mongoDbService;
	}

	public async Task<string?> Execute(string url)
	{
		  var existingUrl =await _mongoDbService.GetUrlAsync(url);
		  
		 return existingUrl?.LongUrl; 
	}
}