﻿using ARSoftware.Contpaqi.Api.Common.Domain;

namespace ARSoftware.Contpaqi.Api.Common.Responses;

/// <summary>
///     Empty response.
/// </summary>
public sealed class EmptyContpaqiResponse : ContpaqiResponse<string>
{
    public EmptyContpaqiResponse() : base("")
    {
    }
}
