using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class UserStory
{
    public int StoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? UserId { get; set; }

    public int? ProjectId { get; set; }

    public virtual Project? Project { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();

    public virtual User? User { get; set; }
}
