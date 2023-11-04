using System;
using System.Collections.Generic;

namespace practice_proyect.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserUsername { get; set; } = null!;

    public bool UserStatus { get; set; }

    public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
}
