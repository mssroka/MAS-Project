using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAS.Data;

public partial class Person
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdPerson { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual Serviceman? Serviceman { get; set; }

    public virtual Trainee? Trainee { get; set; }
}
