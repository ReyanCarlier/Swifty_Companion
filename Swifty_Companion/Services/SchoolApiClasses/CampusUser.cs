using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class CampusUser
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; } = 0;
    [JsonPropertyName("campus_id")]
    public int CampusId { get; set; } = 0;
    [JsonPropertyName("is_primary")]
    public bool IsPrimary { get; set; } = false;
}