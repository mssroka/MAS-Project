using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Diagnosis
{
    public int IdPerson { get; set; }

    public int IdJob { get; set; }

    public string DiagText { get; set; } = null!;

    public virtual Job IdJobNavigation { get; set; } = null!;

    public virtual Manager IdPersonNavigation { get; set; } = null!;
}
