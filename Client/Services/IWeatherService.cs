using System.Threading.Tasks;

namespace Client.Services
{
    public interface IWeatherService
    {
        Task<string> Get();
    }
}
