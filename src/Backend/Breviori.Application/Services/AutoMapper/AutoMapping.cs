using AutoMapper;
using Breviori.Domain.Entities;
using Communication.Response;

namespace Breviori.Application.Services.AutoMapper;

public class AutoMapping: Profile
{
	private readonly string _serverUrl;
	public AutoMapping(string serverUrl)
	{
		_serverUrl = serverUrl;
		EntityToResponse();
	}

	private void EntityToResponse()
	{
		CreateMap<Url, RegisterUrlResponse>()
			.ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.KeyUrl))
			.ForMember(dest => dest.LongUrl, opt => opt.MapFrom(src => src.LongUrl))
			.ForMember(dest => dest.ShortUrl, opt => opt.MapFrom(src => $"{_serverUrl}/{src.KeyUrl}"));
	}
	
	
}