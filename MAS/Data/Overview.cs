using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Overview
{
    public int IdOverview { get; set; }

    public int Cost { get; set; }

    public int IdJob { get; set; }

    public virtual Job IdJobNavigation { get; set; } = null!;

    public virtual ICollection<ServiceActivity> ServiceActivities { get; set; } = new List<ServiceActivity>();
}
