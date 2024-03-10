namespace OfferPageProject.APIService
{
    public interface IAPIService
    {
        Task<T> GetAsync<T>(string endpoint, string token);
        Task<TResponse> PostAsync<TRequest, TResponse>(string endpoint, TRequest data, string token);
        Task<T> GetByIdAsync<T>(string endpoint, string id, string token);
        Task<T> UpdateAsync<T>(string endpoint, T data, string token);
        Task<T> DeleteAsync<T>(string endpoint, int id, string token);
        Task<T> DeleteAsync<T>(string endpoint, string id, string token);
        Task<T> GetAsyncWoToken<T>(string endpoint);
    }
}
