using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class Owner
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("login")]
    public string Login { get; set; } = "";
    [JsonPropertyName("url")]
    public string Url { get; set; } = "";
}