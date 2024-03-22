using Shared;

namespace ControlCambioApi.Services
{
    public interface ITasasServices
    {
        Task<List<ResponseTasas>> GetTasasVenezuela();
        Task<List<ResponseTasas>> GetTasasColombia();
        Task<List<ResponseTasas>> GetTasasPeru();
        Task<List<ResponseTasas>> GetTasasMexico();
        Task<List<ResponseTasas>> GetTasasChile();
        Task<List<ResponseTasas>> GetTasasEcuador();
        Task<List<ResponseTasas>> GetTasasPanama();
        Task<List<ResponseTasas>> GetTasasEEUU();
        Task<List<ResponseTasas>> GetTasasEspaña();
        Task<List<ResponseTasas>> GetTasasArgentina();
        Task<List<ResponseTasas>> GetTasasBrasil();
        Task<bool> UpdateTasas(Pais pais);
        Task<List<Pais>> GetPais();
    }
}
