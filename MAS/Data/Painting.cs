using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Data;

public partial class Painting
{
    public int IdPainting { get; set; }

    public string Colour { get; set; } = null!;

    public static string PaintingName = "Painting";

    public virtual ICollection<PaintingElement> PaintingElements { get; set; } = new List<PaintingElement>();

    public virtual ICollection<ServiceActivity> ServiceActivities { get; set; } = new List<ServiceActivity>();
}
