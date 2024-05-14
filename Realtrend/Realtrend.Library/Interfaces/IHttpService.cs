namespace Realtrend.Library.Interfaces
{
    public interface IHttpService
    {
        Task<string> GetStringAsync(string requestUri);
    }
}
