using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record RateOfDay(
        string countrySend  ,
        string countryRecive ,
        string rate,
        string currencySend,
        string currencyRecive
        );
    
    
}
