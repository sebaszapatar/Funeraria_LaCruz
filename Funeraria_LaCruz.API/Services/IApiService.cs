using Funeraria_LaCruz.Shared.Responses;

namespace Funeraria_LaCruz.API.Services
{
    public interface IApiService
    {

        Task<Response> GetListAsync<T>(string servicePrefix, string controller);

    }
}
