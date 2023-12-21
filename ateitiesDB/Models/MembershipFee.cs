using System;
using System.Collections.Generic;

namespace ateitiesDB.Models;

public partial class Membershipfee
{
    public int Paymentid { get; set; }

    public int Personid { get; set; }

    public decimal Amount { get; set; }

    public DateOnly Paymentdate { get; set; }

    public virtual Person Person { get; set; } = null!;
}
