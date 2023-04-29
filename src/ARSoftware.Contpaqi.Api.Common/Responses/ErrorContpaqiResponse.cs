using ARSoftware.Contpaqi.Api.Common.Domain;

namespace ARSoftware.Contpaqi.Api.Common.Responses;

/// <summary>
///     Error response.
/// </summary>
public class ErrorContpaqiResponse : ContpaqiResponse<string>
{
    public ErrorContpaqiResponse(string error) : base(error)
    {
    }
}
