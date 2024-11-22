using System;
using System.Collections.Generic;

namespace FusepongAPI.Models;

public partial class CommentDto
{
    public int CommentId { get; set; }

    public string? CommentText { get; set; }

    public DateTime? CreationDate { get; set; }

    public string? User { get; set; }
}
