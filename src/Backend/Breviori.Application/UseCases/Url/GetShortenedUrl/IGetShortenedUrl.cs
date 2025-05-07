namespace Breviori.Application.UseCases.Url.GetShortenedUrl;

public interface IGetShortenedUrl
{
	Task<string?> Execute(string url);
}