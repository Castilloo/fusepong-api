using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FusepongAPI.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    [JsonIgnore]
    public string? Password { get; set; }

    public int? CompanyId { get; set; }
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
    [JsonIgnore]
    public virtual Company? Company { get; set; }
    [JsonIgnore]
    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    [JsonIgnore]
    public virtual ICollection<UserStory> UserStories { get; set; } = new List<UserStory>();
}
