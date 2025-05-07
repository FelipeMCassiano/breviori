using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Breviori.Domain.Entities;

public class Url
{
	[BsonId]
	public string KeyUrl { get; set; } = string.Empty;
	
	public string LongUrl { get; set; } = string.Empty;
}