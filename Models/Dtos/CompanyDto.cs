using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class CompanyDto
{
    public int CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Nit { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    // public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
