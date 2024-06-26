﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class LanguageUser
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("language_id")]
    public int LanguageId { get; set; } = 0;
    [JsonPropertyName("user_id")]
    public int UserId { get; set; } = 0;
    [JsonPropertyName("position")]
    public int Position { get; set; } = 0;
    [JsonPropertyName("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.MinValue;
}