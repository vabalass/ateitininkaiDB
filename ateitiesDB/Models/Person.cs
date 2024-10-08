﻿using System;
using System.Collections.Generic;

namespace ateitiesDB.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Country { get; set; }

    public string? Description { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? House { get; set; }

    public string? Apartment { get; set; }

    public DateTime Registrationdate { get; set; }

    public virtual ICollection<Attendsevent>? Attendsevents { get; set; } = new List<Attendsevent>();

    public virtual ICollection<Belongstounit>? Belongstounits { get; set; } = new List<Belongstounit>();

    public virtual ICollection<Pledge>? Pledges { get; set; } = new List<Pledge>();
}
