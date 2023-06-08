using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Service
{
    public int IdService { get; set; }

    public string Address { get; set; } = null!;

    public int MaxEmpAmount { get; set; }

    public int EmpAmount { get; set; }

    public DateTime Opening { get; set; }

    public DateTime Closing { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<Serviceman> Servicemen { get; set; } = new List<Serviceman>();

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
}
