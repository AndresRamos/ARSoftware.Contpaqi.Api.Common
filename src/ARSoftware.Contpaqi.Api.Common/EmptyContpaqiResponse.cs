namespace ARSoftware.Contpaqi.Api.Common;

public sealed class EmptyContpaqiResponse : IContpaqiResponse<string>
{
    public string Model { get; set; } = string.Empty;
}
