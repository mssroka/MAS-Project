using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Data;

public partial class Service
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdService { get; set; }

    public string Address { get; set; } = null!;

    public  int MaxEmpAmount { get; set; }
    public static int MaxEmpAmountVal = 5;

    public int EmpAmount { get; set; }

    public DateTime Opening { get; set; }

    public DateTime Closing { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public virtual ICollection<Manager> Managers { get; set; } = new List<Manager>();

    public virtual ICollection<Serviceman> Servicemen { get; set; } = new List<Serviceman>();

    public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
}
