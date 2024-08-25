using System;
using System.Collections.Generic;

namespace JpMorgans_chayCo_PersonalLoan.DataBaseLogic;

public partial class Student
{
    public int Sid { get; set; }

    public string? Studentname { get; set; }

    public string? StudentAge { get; set; }

    public DateTime? Joindate { get; set; }

    public int? Deptid { get; set; }

    public virtual Dept? Dept { get; set; }
}
