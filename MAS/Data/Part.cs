using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Part
{
    public int IdPart { get; set; }

    public string Name { get; set; } = null!;

    public int Cost { get; set; }

    public virtual ICollection<Replacement> Replacements { get; set; } = new List<Replacement>();
}
