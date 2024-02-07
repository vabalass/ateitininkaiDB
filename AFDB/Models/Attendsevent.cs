using System;
using System.Collections.Generic;

namespace AFDB.Models;

public partial class Attendsevent
{
    public int Id { get; set; }

    public int Eventid { get; set; }

    public int Personid { get; set; }

    public string Position { get; set; } = null!;

    public virtual Event Event { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
