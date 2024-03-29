using System;
using System.Collections.Generic;

namespace HelloDoc.Models;

public partial class Region
{
    public int RegionId { get; set; }

    public string Name { get; set; } = null!;

    public string? Abbreviation { get; set; }

    public virtual ICollection<Concierge> Concierges { get; set; } = new List<Concierge>();

    public virtual ICollection<RequestClient> RequestClients { get; set; } = new List<RequestClient>();
}
