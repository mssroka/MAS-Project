using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Job
{
    public int IdJob { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public int Cost { get; set; }

    public string Status { get; set; } = null!;

    public string? Note { get; set; }

    public int IdCar { get; set; }

    public int IdPerson { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual Car IdCarNavigation { get; set; } = null!;

    public virtual ICollection<Overview> Overviews { get; set; } = new List<Overview>();

    public virtual ICollection<PaintingElement> PaintingElements { get; set; } = new List<PaintingElement>();

    public virtual ICollection<Replacement> Replacements { get; set; } = new List<Replacement>();

    public virtual Serviceman ServicemanIdPersonNavigation { get; set; } = null!;
}
