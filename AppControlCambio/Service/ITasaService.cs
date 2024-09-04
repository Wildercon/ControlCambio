using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppControlCambio.Service
{
    public interface ITasaService
    {
        Task<List<string>> GetCountries();
        Task<List<ResponseTasas>> GetTasas(string pais, int porcentaje);

    }
}
