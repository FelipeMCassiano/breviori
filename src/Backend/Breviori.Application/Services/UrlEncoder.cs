using System.Security.Cryptography;
using System.Text;

namespace Breviori.Application.Services;

public static class UrlEncoder
{

	public static string Encode(string value)
	{
		var bytes = Encoding.UTF8.GetBytes(value);
		var hashString = SHA256.HashData(bytes);
		return Convert.ToHexString(hashString)[..5];
	}
	
}