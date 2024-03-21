using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class Group
{
    [JsonPropertyName("id")]
    [Key]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
}