﻿namespace ARSoftware.Contpaqi.Api.Common;

public interface IContpaqiResponse
{
}

public interface IContpaqiResponse<TModel> : IContpaqiResponse
{
    /// <summary>
    ///     Response model.
    /// </summary>
    public TModel Model { get; set; }
}
