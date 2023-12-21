using System;
using System.Collections.Generic;

namespace ateitiesDB.Models;

public partial class Belongstounit
{
    public int Id { get; set; }

    public int Personid { get; set; }

    public int Unitid { get; set; }

    public string Position { get; set; } = null!;

    public DateOnly Startdate { get; set; }

    public DateOnly Enddate { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
}
