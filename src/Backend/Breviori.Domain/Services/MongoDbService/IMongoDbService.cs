using Breviori.Domain.Entities;

namespace Breviori.Domain.Services.MongoDbService;

public interface IMongoDbService
{
	Task AddUrlAsync(Url url);
	Task<Url?> GetUrlAsync(string shortUrl);
	Task DeleteUrlAsync(string shortUrl);
}