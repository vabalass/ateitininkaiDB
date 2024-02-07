using System;
using System.Collections.Generic;

namespace AFDB.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Organizer { get; set; } = null!;

    public string? Description { get; set; }

    public string? Location { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public virtual ICollection<Attendsevent> Attendsevents { get; set; } = new List<Attendsevent>();

    public virtual ICollection<Pledge> Pledges { get; set; } = new List<Pledge>();
}
