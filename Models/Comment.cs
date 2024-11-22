using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? TicketId { get; set; }

    public int? UserId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? CreationDate { get; set; }

    public virtual Ticket? Ticket { get; set; }

    public virtual User? User { get; set; }
}
