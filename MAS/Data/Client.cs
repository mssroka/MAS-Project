using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Client
{
    public int IdPerson { get; set; }

    public string? Notes { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();

    public virtual Person IdPersonNavigation { get; set; } = null!;
}
