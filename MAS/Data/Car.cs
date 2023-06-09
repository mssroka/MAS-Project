using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Data;

public partial class Car
{
    public int IdCar { get; set; }

    public string Plates { get; set; } = null!;

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int IdPerson { get; set; }

    public virtual Client IdPersonNavigation { get; set; } = null!;

    public virtual ICollection<Job> Jobs { get; set; } = new List<Job>();
}
