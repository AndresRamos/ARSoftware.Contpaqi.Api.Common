using System.Text.Json.Serialization;
using ARSoftware.Contpaqi.Api.Common.Responses;

namespace ARSoftware.Contpaqi.Api.Common.Domain;

/// <summary>
///     Response model used by the API.
/// </summary>
public sealed class ApiResponse
{
    public ApiResponse(ContpaqiResponse contpaqiResponse, bool isSuccess, string errorMessage = "")
    {
        ContpaqiResponseType = contpaqiResponse.GetType().Name;
        ContpaqiResponse = contpaqiResponse;
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
    }

    /// <summary>
    ///     Id de la respuesta.
    /// </summary>
    [JsonInclude]
    public Guid Id { get; private set; }

    /// <summary>
    ///     Fecha de creacion de la respuesta.
    /// </summary>
    [JsonInclude]
    public DateTimeOffset DateCreated { get; private set; } = DateTimeOffset.Now;

    /// <summary>
    ///     Resultado de si fue exitosa la solicitud.
    /// </summary>
    [JsonInclude]
    public bool IsSuccess { get; private set; }

    /// <summary>
    ///     Tipo de respuesta CONTPAQi.
    /// </summary>
    [JsonInclude]
    public string ContpaqiResponseType { get; private set; }

    /// <summary>
    ///     Respuesta CONTPAQi.
    /// </summary>
    [JsonInclude]
    public ContpaqiResponse ContpaqiResponse { get; private set; }

    /// <summary>
    ///     Mensaje de error.
    /// </summary>
    [JsonInclude]
    public string ErrorMessage { get; private set; }

    /// <summary>
    ///     Tiempo de ejecucion en milisegundos.
    /// </summary>
    [JsonInclude]
    public long ExecutionTime { get; set; }

    /// <summary>
    ///     Creates a successfull response.
    /// </summary>
    /// <param name="contpaqiResponse">CONTPAQi Response.</param>
    /// <returns>An API Response with the CONTPAQi Response as model.</returns>
    public static ApiResponse CreateSuccessfull(ContpaqiResponse contpaqiResponse)
    {
        return new ApiResponse(contpaqiResponse, true);
    }

    /// <summary>
    ///     Creates a failed response.
    /// </summary>
    /// <param name="exception">Exception</param>
    /// <returns>An API response with the Exception message as model.</returns>
    public static ApiResponse CreateFailed(Exception exception)
    {
        return new ApiResponse(new ErrorContpaqiResponse(exception.ToString()), false, exception.Message);
    }

    /// <summary>
    ///     Creates a failed response.
    /// </summary>
    /// <param name="errorMessage">Error message.</param>
    /// <returns>An API response with the error message as model.</returns>
    public static ApiResponse CreateFailed(string errorMessage)
    {
        return new ApiResponse(new ErrorContpaqiResponse(errorMessage), false, errorMessage);
    }
}
