using System;
using System.Collections.Generic;

namespace ControlCambioApi.Models;

public partial class DataCommission
{
    public int Id { get; set; }

    public int? PaisE { get; set; }

    public int? PaisR { get; set; }

    public string? Op { get; set; }

    public int? Por { get; set; }

    public int? Decimals { get; set; }

    public bool? IsE { get; set; }

    public virtual TasasP? PaisENavigation { get; set; }

    public virtual TasasP? PaisRNavigation { get; set; }
}
