using System;
using System.Collections.Generic;

namespace practice_proyect.Model;

public partial class Vehicle
{
    public int VehiId { get; set; }

    public string VehiBrand { get; set; } = null!;

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
