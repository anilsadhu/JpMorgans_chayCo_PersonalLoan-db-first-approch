using System;
using System.Collections.Generic;

namespace JpMorgans_chayCo_PersonalLoan.DataBaseLogic;

public partial class CustomerRegidtation
{
    public int Cid { get; set; }

    public string? CustomerName { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }
}
