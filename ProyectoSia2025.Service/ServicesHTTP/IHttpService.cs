using ProyectoSia2025.Service.ServicesHTTP;

namespace ProyectoSia2025.Service.ServiciosHTTP
{
    public interface IHttpService
    {
        Task<HttpResponse<T>> Get<T>(string url);
        Task<HttpResponse<TResp>> Post<T, TResp>(string url, T entidad);
    }
}