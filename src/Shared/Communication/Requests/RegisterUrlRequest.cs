using System.ComponentModel.DataAnnotations;

namespace Communication.Requests;

public class RegisterUrlRequest
{
	[Required]
	public string Url { get; set; } = string.Empty;
}