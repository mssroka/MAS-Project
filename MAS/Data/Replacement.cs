using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Replacement
{
    public int IdPartsExchange { get; set; }

    public int IdJob { get; set; }

    public int IdPart { get; set; }

    public virtual Job IdJobNavigation { get; set; } = null!;

    public virtual Part IdPartNavigation { get; set; } = null!;

    public virtual PartsExchange IdPartsExchangeNavigation { get; set; } = null!;
}
