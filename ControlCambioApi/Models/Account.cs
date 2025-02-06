using System;
using System.Collections.Generic;

namespace ControlCambioApi.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string? Accountnumber { get; set; }

    public string? Observation { get; set; }

    public string? IdOwner { get; set; }

    public string? Bank { get; set; }
}
