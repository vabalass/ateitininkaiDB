using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class DalyvaujaRenginyje
{
    public int Nr { get; set; }

    public int RenginioNr { get; set; }

    public int AsmensNr { get; set; }

    public string Pareigybe { get; set; } = null!;

    public virtual Asmuo AsmensNrNavigation { get; set; } = null!;

    public virtual Renginy RenginioNrNavigation { get; set; } = null!;
}
