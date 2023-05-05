using ARSoftware.Contpaqi.Api.Common.Domain;

namespace ARSoftware.Contpaqi.Api.Common.Responses;

/// <summary>
///     Error response.
/// </summary>
public class ErrorContpaqiResponse : ContpaqiResponse<string>
{
    /// <summary>
    ///     Instantiates a new error response.
    /// </summary>
    /// <param name="model">Error message.</param>
    public ErrorContpaqiResponse(string model) : base(model)
    {
    }
}
