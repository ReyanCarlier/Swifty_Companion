using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class Accreditation
{
    [JsonPropertyName("id")]
    [Key]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    [JsonPropertyName("user_id")]
    public int UserId { get; set; } = 0;
    [JsonPropertyName("cursus_id")]
    public int CursusId { get; set; } = 0;
    [JsonPropertyName("validated")]
    public bool Validated { get; set; } = false;
}
