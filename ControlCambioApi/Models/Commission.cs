using System;
using System.Collections.Generic;

namespace ControlCambioApi.Models;

public partial class Commission
{
    public int Id { get; set; }

    public string Pais { get; set; } = null!;

    public string PaisR { get; set; } = null!;

    public string Op { get; set; } = null!;

    public int Por { get; set; }

    public int Decimals { get; set; }

    public bool IsE { get; set; }

    public virtual ICollection<TasasP> TasasPs { get; set; } = new List<TasasP>();
}
