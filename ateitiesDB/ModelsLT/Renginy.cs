using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class Renginy
{
    public int Nr { get; set; }

    public string Pavadinimas { get; set; } = null!;

    public string Organizatorius { get; set; } = null!;

    public string? Aprasymas { get; set; }

    public string? Vieta { get; set; }

    public DateTime DataNuo { get; set; }

    public DateTime DataIki { get; set; }

    public virtual ICollection<DalyvaujaRenginyje> DalyvaujaRenginyjes { get; set; } = new List<DalyvaujaRenginyje>();

    public virtual ICollection<Izodi> Izodis { get; set; } = new List<Izodi>();
}
