using System;
using System.Collections.Generic;

namespace JpMorgans_chayCo_PersonalLoan.DataBaseLogic;

public partial class Dept
{
    public int Deptid { get; set; }

    public string? DeptName { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

}
