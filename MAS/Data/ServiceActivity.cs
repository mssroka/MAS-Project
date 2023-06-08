using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class ServiceActivity
{
    public int IdServiceActivity { get; set; }

    public string Name { get; set; }

    public int DifficultyLevel { get; set; }
    public DateTime ServiceDate { get; set; }

    public int? IdOverview { get; set; }

    public int? IdPartsExchange { get; set; }

    public int? IdPainting { get; set; }

    public virtual Overview? IdOverviewNavigation { get; set; }

    public virtual Painting? IdPaintingNavigation { get; set; }

    public virtual PartsExchange? IdPartsExchangeNavigation { get; set; }
}
