using Shared;

namespace ControlCambioApi.Services
{
    public interface ITasasServices
    {
        Task<List<ResponseTasas>> GetTasas(decimal por, string pais);
        
        Task<bool> UpdateTasas(Pais pais);
        Task<List<Pais>> GetPais();

        Task<RateOfDay> GetTasaPreferencials();
    }
}
