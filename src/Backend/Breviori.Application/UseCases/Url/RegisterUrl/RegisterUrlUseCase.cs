using AutoMapper;
using Breviori.Application.Services;
using Breviori.Domain.Services.MongoDbService;
using Communication.Requests;
using Communication.Response;

namespace Breviori.Application.UseCases.Url.RegisterUrl;

public class RegisterUrlUseCase : IRegisterUrlUseCase
{
	private readonly IMongoDbService _mongoDbService;
	private readonly IMapper _mapper;
	
	public RegisterUrlUseCase(IMongoDbService mongoDbService, IMapper mapper)
	{
		_mongoDbService = mongoDbService;
		_mapper = mapper;
	}
	public async Task<RegisterUrlResponse> Execute(RegisterUrlRequest request)
	{
		var keyUrl = UrlEncoder.Encode(request.Url);
		var existingUrl = await _mongoDbService.GetUrlAsync(keyUrl);
		if (existingUrl != null)
		{
			return _mapper.Map<RegisterUrlResponse>(existingUrl);
		}

		var newUrl = new Domain.Entities.Url
		{
			KeyUrl = keyUrl,
			LongUrl = request.Url, 
		};
		await _mongoDbService.AddUrlAsync(newUrl);
		
		return _mapper.Map<RegisterUrlResponse>(newUrl);
	}
}