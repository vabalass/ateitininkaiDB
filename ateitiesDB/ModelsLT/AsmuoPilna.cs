using System;
using System.Collections.Generic;

namespace ateitiesDB.ModelsLT;

public partial class AsmuoPilna
{
    public int? Nr { get; set; }

    public string? Vardas { get; set; }

    public string? Pavarde { get; set; }

    public string? Lytis { get; set; }

    public DateOnly? GimData { get; set; }

    public decimal? Amzius { get; set; }

    public string? ElPastas { get; set; }

    public string? TelNr { get; set; }

    public string? Aprasymas { get; set; }

    public string? Krastas { get; set; }

    public string? Adresas { get; set; }

    public string? NarystesStatusas { get; set; }

    public DateTime? RegistravimoData { get; set; }

    public DateTime? PaskutinioRenginioData { get; set; }
}
