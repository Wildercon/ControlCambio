using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record TasaPreferencial(
        string PaisSend,
        string PaisRecive,
        decimal Tasa
        );
    
}
