using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class Cursus
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("slug")]
    public string Slug { get; set; } = "";
}