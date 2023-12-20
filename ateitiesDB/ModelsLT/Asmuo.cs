using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class Asmuo
{
    public int Nr { get; set; }

    public string Vardas { get; set; } = null!;

    public string Pavarde { get; set; } = null!;

    public string Lytis { get; set; } = null!;

    public DateOnly GimData { get; set; }

    public string? ElPastas { get; set; }

    public string? TelNr { get; set; }

    public string? Krastas { get; set; }

    public string? Aprasymas { get; set; }

    public string? Gatve { get; set; }

    public string? Miestas { get; set; }

    public string? Namas { get; set; }

    public string? Butas { get; set; }

    public DateTime RegistravimoData { get; set; }

    public virtual ICollection<DalyvaujaRenginyje> DalyvaujaRenginyjes { get; set; } = new List<DalyvaujaRenginyje>();

    public virtual ICollection<Izodi> Izodis { get; set; } = new List<Izodi>();

    public virtual ICollection<PriklausoVienetui> PriklausoVienetuis { get; set; } = new List<PriklausoVienetui>();
}
