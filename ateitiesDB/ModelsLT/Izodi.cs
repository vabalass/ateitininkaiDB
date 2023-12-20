using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class Izodi
{
    public int Nr { get; set; }

    public int AsmensNr { get; set; }

    public string Sajunga { get; set; } = null!;

    public DateOnly IzodzioData { get; set; }

    public int? RenginioNr { get; set; }

    public virtual Asmuo AsmensNrNavigation { get; set; } = null!;

    public virtual Renginy? RenginioNrNavigation { get; set; }
}
