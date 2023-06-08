using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class PaintingElement
{
    public int IdElement { get; set; }

    public int IdPainting { get; set; }

    public int IdJob { get; set; }

    public virtual Element IdElementNavigation { get; set; } = null!;

    public virtual Job IdJobNavigation { get; set; } = null!;

    public virtual Painting IdPaintingNavigation { get; set; } = null!;
}
