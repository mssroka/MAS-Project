using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Element
{
    public int IdElement { get; set; }
    public string Name { get; set; } = null!;
    public int Cost { get; set; }
    public virtual ICollection<PaintingElement> PaintingElements { get; set; } = new List<PaintingElement>();
}
