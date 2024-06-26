using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class Announcement
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("author")]
    public string Author { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("text")]
    public string Text { get; set; }
    [JsonPropertyName("kind")]
    public string Kind { get; set; }
    [JsonPropertyName("link")]
    public string Link { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; }
    [JsonPropertyName("updated_at")]
    public DateTime UpdatedAt { get; set; }
    [JsonPropertyName("expire_at")]
    public DateTime? ExpireAt { get; set; }
}