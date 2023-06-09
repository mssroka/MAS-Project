using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Trainee
{
    public int IdPerson { get; set; }

    public static int Salary { get; set; } = 1000;

    public DateTime InternshipStartDate { get; set; }

    public int LengthOfInternship { get; set; }

    public int IdService { get; set; }

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;
}
