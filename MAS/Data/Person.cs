using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Person
{
    public int IdPerson { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int PhoneNumber { get; set; }

    public virtual Client? Client { get; set; }

    public virtual Manager? Manager { get; set; }

    public virtual Serviceman? Serviceman { get; set; }

    public virtual Trainee? Trainee { get; set; }
}
