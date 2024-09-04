using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public record AccountDTO (
        int Id,
        string Name,
        string Country,
        string AccountNumber,
        string Observation,
        string IdOwner,
        string Bank
        );
    
        
}
