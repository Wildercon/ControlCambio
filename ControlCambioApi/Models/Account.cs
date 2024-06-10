using System;
using System.Collections.Generic;

namespace ControlCambioApi.Models;

public partial class Account
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public string Accountnumber { get; set; } = null!;

    public string Mont { get; set; } = null!;
}
