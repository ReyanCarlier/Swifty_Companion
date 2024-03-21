using System;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class ProjectsUser
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("occurrence")]
    public int Occurrence { get; set; }

    [JsonPropertyName("final_mark")]
    public int? FinalMark { get; set; } // Nullable for cases where the project hasn't been marked yet

    [JsonPropertyName("status")]
    public string Status { get; set; } = "";

    [JsonPropertyName("validated?")]
    public bool? IsValidated { get; set; } // Nullable because it can be null if not marked yet

    [JsonPropertyName("current_team_id")]
    public int? CurrentTeamId { get; set; } // Nullable for cases where there might not be a team

    [JsonPropertyName("project")]
    public Project Project { get; set; }

    [JsonPropertyName("cursus_ids")]
    public List<int> CursusIds { get; set; }

    [JsonPropertyName("marked_at")]
    public DateTime? MarkedAt { get; set; } // Nullable for cases where it hasn't been marked yet

    [JsonPropertyName("marked")]
    public bool Marked { get; set; }

    [JsonPropertyName("retriable_at")]
    public DateTime? RetriableAt { get; set; } // Nullable because it might not be retriable

    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
}

public class Project
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("slug")]
    public string Slug { get; set; }

    [JsonPropertyName("parent_id")]
    public int? ParentId { get; set; } // Nullable for projects that are not sub-projects
}

