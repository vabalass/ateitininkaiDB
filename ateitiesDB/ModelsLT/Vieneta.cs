using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class Vieneta
{
    public int Nr { get; set; }

    public string Pavadinimas { get; set; } = null!;

    public string Tipas { get; set; } = null!;

    public string? Aprasymas { get; set; }

    public string? Adresas { get; set; }

    public DateOnly IkurimoData { get; set; }

    public virtual ICollection<PriklausoVienetui> PriklausoVienetuis { get; set; } = new List<PriklausoVienetui>();
}
