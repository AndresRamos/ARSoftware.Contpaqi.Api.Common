namespace ARSoftware.Contpaqi.Api.Common.Domain;

/// <summary>
///     Abstract class used by CONTPAQi Responses.
/// </summary>
public abstract class ContpaqiResponse
{
}

/// <summary>
///     Abstract class used by CONTPAQi Responses.
/// </summary>
/// <typeparam name="TModel">Resposne model.</typeparam>
public abstract class ContpaqiResponse<TModel> : ContpaqiResponse
{
    protected ContpaqiResponse(TModel model)
    {
        Model = model;
    }

    /// <summary>
    ///     Response model.
    /// </summary>
    public TModel Model { get; set; }
}
