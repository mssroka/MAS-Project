using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Manager
{
    public int IdPerson { get; set; }

    public int Pesel { get; set; }

    public DateTime HireDate { get; set; }

    public DateTime PromotionDate { get; set; }

    public int IdService { get; set; }

    public virtual ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;
}
