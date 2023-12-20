using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class NarioMokesti
{
    public int ApmokejimoNr { get; set; }

    public int AsmensNr { get; set; }

    public decimal Suma { get; set; }

    public DateTime ApmokejimoData { get; set; }

    public virtual Asmuo AsmensNrNavigation { get; set; } = null!;
}
