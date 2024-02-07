using System;
using System.Collections.Generic;

namespace AFDB.Models;

public partial class Pledge
{
    public int Id { get; set; }

    public int Personid { get; set; }

    public string Association { get; set; } = null!;

    public DateOnly Date { get; set; }

    public int? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual Person Person { get; set; } = null!;
}
