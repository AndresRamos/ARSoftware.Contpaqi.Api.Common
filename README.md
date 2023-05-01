# AR Software CONTPAQi API Common

Este paquete contiene las clases comunes para el consumo de los servicios de las APIs de CONTPAQi.

## APIs que utilizan este paquete:
* [AR Software - CONTPAQi Comercial API](https://github.com/AndresRamos/ARSoftware.Contpaqi.Comercial.Api)
* [AR Software - CONTPAQi Contabilidad API](https://github.com/AndresRamos/ARSoftware.Contpaqi.Contabilidad.Api)
* [AR Software - CONTPAQi Nominas API](https://github.com/AndresRamos/ARSoftware.Contpaqi.Nominas.Api)

## Instalación
```
dotnet add package ARSoftware.Contpaqi.Common
```

## ApiRequest
Esta clase representa el modelo de una solicitud.

* **`Id`** - Id de la solicitud.
* **`SubscriptionKey`** - Licencia del consumidor de la API.
* **`EmpresaRfc`** - RFC de la empresa.
* **`DateCreated`** - Fecha de creacion de la solicitud.
* **`ContpaqiRequestType`** - Tipo de solicitud CONTPAQi.
* **`ContpaqiRequest`** - Solicitud CONTPAQi.
* **`Status`** - Estatus de la solicitud.
* **`Response`** - Respuesta de la solicitud.

## ContpaqiRequest
Esta clase representa el modelo de una solicitud CONTPAQi. Esta solicitud sera procesada por el sincronizador del sistema CONTPAQi. Cada sistema definira sus propias solicitudes. Todas las solicitudes CONTPAQi deben heredar de esta clase.

```csharp
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
```

Las solicitudes CONTPAQi tienen la misma estructura. Todas deben tener una propiedad `Model` y una propiedad `Options`. Las solicitudes se diferencian por el tipo de estas propiedades y cada solicitud definirar sus tipos de modelo y opciones.

### La solicitud CONTPAQi `BuscarEmpresasRequest` para buscar empresas tiene la siguiente estructura:

```csharp
public sealed class BuscarEmpresasRequest : ContpaqiRequest<BuscarEmpresasRequestModel, BuscarEmpresasRequestOptions, BuscarEmpresasResponse>
{
    public BuscarEmpresasRequest(BuscarEmpresasRequestModel model, BuscarEmpresasRequestOptions options) : base(model, options)
    {
    }
}

public sealed class BuscarEmpresasRequestModel
{
}

public sealed class BuscarEmpresasRequestOptions : ILoadRelatedDataOptions
{
    public bool CargarDatosExtra { get; set; }
}
```

* **`BuscarEmpresasRequestModel`** - Modelo de la solicitud sin propiedades.
* **`BuscarEmpresasRequestOptions`** - Opciones de la solicitud. En este caso, la solicitud tiene una opcion para cargar datos extra.

### La solicitud CONTPAQi `BuscarEmpleadosRequest` para buscar empleados tiene la siguiente estructura:

```
public sealed class BuscarEmpleadosRequest : ContpaqiRequest<BuscarEmpleadosRequestModel, BuscarEmpleadosRequestOptions, BuscarEmpleadosResponse>
{
    public BuscarEmpleadosRequest(BuscarEmpleadosRequestModel model, BuscarEmpleadosRequestOptions options) : base(model, options)
    {
    }
}

public sealed class BuscarEmpleadosRequestModel
{
    public int? Id { get; set; }
    public string? Codigo { get; set; }
    public string? Rfc { get; set; }
    public string? Curp { get; set; }
    public string? SqlQuery { get; set; }
}

public sealed class BuscarEmpleadosRequestOptions : ILoadRelatedDataOptions
{
    public bool CargarDatosExtra { get; set; }
}
```

* **`BuscarEmpleadosRequestModel`** - Modelo de la solicitud con propiedades para buscar empleados.
* **`BuscarEmpleadosRequestOptions`** - Opciones de la solicitud. En este caso, la solicitud tiene una opcion para cargar datos extra.

## ApiResponse
Esta clase representa el modelo de una respuesta.
* **`Id`** - Id de la respuesta.
* **`DateCreated`** - Fecha de creacion de la respuesta.
* **`IsSuccess`** - Resultado de si fue exitosa la solicitud.
* **`ContpaqiResponseType`** - Tipo de respuesta CONTPAQi.
* **`ContpaqiResponse`** - Respuesta CONTPAQi.
* **`ErrorMessage`** - Mensaje de error.
* **`ExecutionTime`** - Tiempo de ejecucion en milisegundos.


## ContpaqiResponse
Esta clase representa el modelo de una respuesta CONTPAQi. Cada sistema definira sus propias respuestas. Todas las respuestas CONTPAQi deben heredar de esta clase.

```csharp
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
```

Todas las respuestas CONTPAQi tienen la misma estructura. Todas deben tener un una propiedad `Model`.

### La respuesta CONTPAQi `BuscarEmpresasResponse` para buscar empresas tiene la siguiente estructura:

```csharp
public sealed class BuscarEmpresasResponse : ContpaqiResponse<BuscarEmpresasResponseModel>
{
    public BuscarEmpresasResponse(BuscarEmpresasResponseModel model) : base(model)
    {
    }
}

public sealed class BuscarEmpresasResponseModel
{
    public int NumeroRegistros => Empresas.Count;
    public List<Empresa> Empresas { get; set; } = new();
}
```

* **`BuscarEmpresasResponseModel`** - Modelo de la respuesta con una propiedad para la lista de empresas.