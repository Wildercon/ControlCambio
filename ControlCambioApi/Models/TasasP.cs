﻿using System;
using System.Collections.Generic;

namespace ControlCambioApi.Models;

public partial class TasasP
{
    public int Id { get; set; }

    public string Pais { get; set; } = null!;

    public string TipoMoneda { get; set; } = null!;

    public decimal ValorMoneda { get; set; }

    public required string FechaA { get; set; }

    public virtual ICollection<DataCommission> DataCommissionPaisENavigations { get; set; } = new List<DataCommission>();

    public virtual ICollection<DataCommission> DataCommissionPaisRNavigations { get; set; } = new List<DataCommission>();
}
