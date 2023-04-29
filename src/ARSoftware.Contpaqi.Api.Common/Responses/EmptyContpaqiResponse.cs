using ARSoftware.Contpaqi.Api.Common.Interfaces;

namespace ARSoftware.Contpaqi.Api.Common.Responses;

public sealed class EmptyContpaqiResponse : IContpaqiResponse<string>
{
    public string Model { get; set; } = string.Empty;
}
