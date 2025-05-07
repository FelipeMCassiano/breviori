using Breviori.Application.UseCases.Url.GetShortenedUrl;
using Breviori.Application.UseCases.Url.RegisterUrl;
using Communication.Requests;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Breviori.API.Controllers;

    [Route("")]
    [ApiController]
    public class UrlController : ControllerBase
    {
	    [HttpPost]
	    [ProducesResponseType(typeof(RegisterUrlResponse), StatusCodes.Status201Created)]
	    public async Task<ActionResult> Post([FromServices] IRegisterUrlUseCase useCase,[FromBody] RegisterUrlRequest request)
	    {
		    var response = await useCase.Execute(request);
		    return Created(string.Empty, response);
	    }

	    [HttpGet]
	    [Route("{url}")]
	    [ProducesResponseType(StatusCodes.Status302Found)]
	    [ProducesResponseType(StatusCodes.Status404NotFound)]
	    public async Task<ActionResult> Get(string url, [FromServices] IGetShortenedUrl useCase)
	    {
		    var longUrl = await useCase.Execute(url);
		    if (longUrl == null) return NotFound(null);
		    
		    return Redirect(longUrl);
	    }
    }

