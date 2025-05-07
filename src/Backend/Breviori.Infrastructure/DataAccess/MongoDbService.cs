using Breviori.Domain.Entities;
using Breviori.Domain.Services.MongoDbService;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Breviori.Infrastructure.DataAccess;

public class MongoDbService: IMongoDbService
{
	private readonly IMongoCollection<Url> _urlsCollection;

	public MongoDbService(IOptions<BrevioriDatabaseSettings> settings)
	{
		var mongoClient = new MongoClient(settings.Value.ConnectionString);
		var mongoDatabase = mongoClient.GetDatabase(settings.Value.DatabaseName);
		_urlsCollection = mongoDatabase.GetCollection<Url>(settings.Value.UrlCollectionName);
	}

	public async Task AddUrlAsync(Url url)
	{
		await _urlsCollection.InsertOneAsync(url);
	}

	public async Task<Url?> GetUrlAsync(string shortUrl)
	{
		return await _urlsCollection.Find(x => x.KeyUrl == shortUrl).FirstOrDefaultAsync();
	}

	public async Task DeleteUrlAsync(string shortUrl)
	{
		await _urlsCollection.DeleteOneAsync(x => x.KeyUrl == shortUrl);
	}
	
}