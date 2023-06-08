using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Serviceman
{
    public int IdPerson { get; set; }

    public int Pesel { get; set; }

    public DateTime HireDate { get; set; }

    public int Skills { get; set; }

    public int RepairAmount { get; set; }

    public int IdService { get; set; }

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
