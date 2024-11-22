using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class Ticket
{
    public int TicketId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? StatusId { get; set; }

    public int? StoryId { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Status? Status { get; set; }

    public virtual UserStory? Story { get; set; }

    public virtual User? User { get; set; }
}
