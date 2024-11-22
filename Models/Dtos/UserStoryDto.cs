using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class UserStoryDto
{
    public int StoryId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? EndDate { get; set; }

    // public virtual Project? Project { get; set; }

    public ICollection<TicketDto> Tickets { get; set; } = new List<TicketDto>();

    public string? User { get; set; }
}
