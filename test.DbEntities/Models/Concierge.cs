﻿using System;
using System.Collections.Generic;

namespace test.DbEntities.Models;

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

    public int RegionId { get; set; }

    public string? RoleId { get; set; }

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<RequestConcierge> RequestConcierges { get; set; } = new List<RequestConcierge>();
}
