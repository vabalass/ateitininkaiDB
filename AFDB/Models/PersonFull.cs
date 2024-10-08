﻿using System;
using System.Collections.Generic;

namespace AFDB.Models;

public partial class PersonFull
{
    public int? Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Gender { get; set; }

    public DateOnly? Birthdate { get; set; }

    public int? Age { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Description { get; set; }

    public string? Country { get; set; }

    public string? Address { get; set; }

    public string? Membershipstatus { get; set; }

    public DateTime? Registrationdate { get; set; }

    public DateTime? Lasteventdate { get; set; }
}
