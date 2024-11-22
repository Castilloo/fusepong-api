using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class Project
{
    public int ProjectId { get; set; }

    public string? Name { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<UserStory> UserStories { get; set; } = new List<UserStory>();
}
