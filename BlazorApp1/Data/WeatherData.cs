using System.Text.Json.Serialization;

namespace BlazorApp1.Data
{
    public record Geometry(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("coordinates")] IReadOnlyList<List<double>> Coordinates
    );

    public record Parameter(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("levelType")] string LevelType,
        [property: JsonPropertyName("level")] int Level,
        [property: JsonPropertyName("unit")] string Unit,
        [property: JsonPropertyName("values")] IReadOnlyList<double> Values
    );

    public record WeatherData(
        [property: JsonPropertyName("approvedTime")] DateTime ApprovedTime,
        [property: JsonPropertyName("referenceTime")] DateTime ReferenceTime,
        [property: JsonPropertyName("geometry")] Geometry Geometry,
        [property: JsonPropertyName("timeSeries")] IReadOnlyList<TimeSeries> TimeSeries
    );

    public record TimeSeries(
        [property: JsonPropertyName("validTime")] DateTime ValidTime,
        [property: JsonPropertyName("parameters")] IReadOnlyList<Parameter> Parameters
    );
}
