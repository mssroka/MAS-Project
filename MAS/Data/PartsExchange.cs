using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Data;

public partial class PartsExchange
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPartsExchange { get; set; }

    public static string PEName = "Parts Exchange";

    public virtual ICollection<Replacement> Replacements { get; set; } = new List<Replacement>();

    public virtual ICollection<ServiceActivity> ServiceActivities { get; set; } = new List<ServiceActivity>();
}
