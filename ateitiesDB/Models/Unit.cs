using System;
using System.Collections.Generic;

namespace ateitiesDB.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Type { get; set; } = null!;

    public string? Description { get; set; }

    public string? Address { get; set; }

    public DateOnly Establishmentdate { get; set; }

    public virtual ICollection<Belongstounit> Belongstounits { get; set; } = new List<Belongstounit>();
}
