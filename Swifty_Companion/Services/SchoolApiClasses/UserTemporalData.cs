using System.Text.Json.Serialization;

namespace Swifty_Companion.Services.SchoolApiClasses;

public class UserTemporalData
{
    [JsonPropertyName("date")]
    public DateTime Date { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }

}