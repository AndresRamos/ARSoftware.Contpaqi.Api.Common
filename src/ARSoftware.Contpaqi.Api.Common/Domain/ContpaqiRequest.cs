using MediatR;

namespace ARSoftware.Contpaqi.Api.Common.Domain;

/// <summary>
///     Abstract class used by CONTPAQi Requests.
/// </summary>
public abstract class ContpaqiRequest
{
}

/// <summary>
///     Abstract class used by CONTPAQi Requests.
/// </summary>
/// <typeparam name="TModel">Request model.</typeparam>
/// <typeparam name="TOptions">Request options.</typeparam>
/// <typeparam name="TResponse">Request response.</typeparam>
public abstract class ContpaqiRequest<TModel, TOptions, TResponse> : ContpaqiRequest, IRequest<TResponse> where TResponse : ContpaqiResponse
{
    protected ContpaqiRequest(TModel model, TOptions options)
    {
        Model = model;
        Options = options;
    }

    /// <summary>
    ///     Request model.
    /// </summary>
    public TModel Model { get; set; }

    /// <summary>
    ///     Request options.
    /// </summary>
    public TOptions Options { get; set; }
}
