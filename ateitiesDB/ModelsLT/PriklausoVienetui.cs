using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class PriklausoVienetui
{
    public int Nr { get; set; }

    public int AsmensNr { get; set; }

    public int VienetoNr { get; set; }

    public string Pareigybe { get; set; } = null!;

    public DateOnly DataNuo { get; set; }

    public DateOnly DataIki { get; set; }

    public virtual Asmuo AsmensNrNavigation { get; set; } = null!;

    public virtual Vieneta VienetoNrNavigation { get; set; } = null!;
}
