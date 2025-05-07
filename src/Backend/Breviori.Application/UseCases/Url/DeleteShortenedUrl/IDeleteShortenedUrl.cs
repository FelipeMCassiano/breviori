namespace Breviori.Application.UseCases.Url.DeleteShortenedUrl;

public interface IDeleteShortenedUrl
{
	Task Execute(string url);
}