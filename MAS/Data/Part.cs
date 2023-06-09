using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Data;

public partial class Part
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPart { get; set; }

    public string Name { get; set; } = null!;

    public int Cost { get; set; }

    public virtual ICollection<Replacement> Replacements { get; set; } = new List<Replacement>();
}
