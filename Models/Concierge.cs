﻿using System;
using System.Collections.Generic;

namespace HelloDoc.Models;

public partial class Concierge
{
    public int ConciergeId { get; set; }

    public string ConciergeName { get; set; } = null!;

    public string? Address { get; set; }

    public string Street { get; set; } = null!;

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int? RegionId { get; set; }

    public int? RoleId { get; set; }

    public virtual Region? Region { get; set; }
}
