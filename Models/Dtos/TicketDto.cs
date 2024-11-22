using System.Text.Json.Serialization;

namespace FusepongAPI.Models;

public partial class TicketDto
{
    public int TicketId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    // public int? StatusId { get; set; }

    public int? StoryId { get; set; }

    // public int? UserId { get; set; }
    public virtual ICollection<CommentDto> Comments { get; set; } = new List<CommentDto>();

    public string? Status { get; set; }

    public virtual UserStory? Story { get; set; }

    public string? User { get; set; }
}