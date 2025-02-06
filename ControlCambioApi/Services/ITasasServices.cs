using ControlCambioApi.Models;
using Shared;

namespace ControlCambioApi.Services
{
    public interface ITasasServices
    {
        Task<List<ResponseTasas>> GetTasas(decimal por, string pais);
        
        Task<bool> UpdateTasas(TasasPDTO pais);
        Task<List<TasasPDTO>> GetPais();

        Task<RateOfDay> GetTasaPreferencials();
    }
}
