using System;
using System.Collections.Generic;

namespace AFDB.Models;

public partial class Membershipfee
{
    public int Id { get; set; }

    public int Personid { get; set; }

    public decimal Amount { get; set; }

    public DateOnly Paymentdate { get; set; }

    public string? Description { get; set; }

    public virtual Person Person { get; set; } = null!;
}
