using System;
using System.Collections.Generic;

namespace practice_proyect.Models;

public partial class Parent
{
    public int ParentId { get; set; }

    public string ParentName { get; set; } = null!;

    public bool ParentStatus { get; set; }
}
