using System;
using System.Collections.Generic;

namespace AFDB.OthetModels.ModelsForFileReading;

public partial class MembershipfeeCsv
{
    public string? Personfirstname { get; set; }

    public string? Personlastname { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? Paymentdate { get; set; }

    public string? Description { get; set; }

    public string? Membershipstatus { get; set; }
}
