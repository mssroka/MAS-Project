using System;
using System.Collections.Generic;

namespace MAS.Data;

public partial class Trainee
{
    public int IdPerson { get; set; }
    public  int Salary { get; set; }
    public static int SalaryVal= 2000;
    public DateTime InternshipStartDate { get; set; }

    public int LengthOfInternship { get; set; }

    public int IdService { get; set; }

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual Service IdServiceNavigation { get; set; } = null!;
}
