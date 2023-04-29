using ARSoftware.Contpaqi.Api.Common.Domain;
using MediatR;

namespace ARSoftware.Contpaqi.Api.Common.Interfaces;

public interface IContpaqiRequest : IRequest<ApiResponse>
{
}

public interface IContpaqiRequest<TModel, TOptions> : IContpaqiRequest
{
    /// <summary>
    ///     Request model.
    /// </summary>
    public TModel Model { get; set; }

    /// <summary>
    ///     Request options.
    /// </summary>
    public TOptions Options { get; set; }
}
