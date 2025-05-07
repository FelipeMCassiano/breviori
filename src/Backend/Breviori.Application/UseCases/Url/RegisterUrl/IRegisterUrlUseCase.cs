using Communication.Requests;
using Communication.Response;

namespace Breviori.Application.UseCases.Url.RegisterUrl;

public interface IRegisterUrlUseCase
{
	Task<RegisterUrlResponse> Execute(RegisterUrlRequest request);
}