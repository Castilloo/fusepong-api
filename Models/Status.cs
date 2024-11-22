using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class Status
{
    public int StatusId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
