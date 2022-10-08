using System.Text.Json.Serialization;

namespace BabyKusto.Server.Contract
{
    public class KustoApiColumnDescription
    {
        [JsonPropertyName("ColumnName")]
        public string? ColumnName { get; set; }

        [JsonPropertyName("DataType")]
        public string? DataType { get; set; }

        [JsonPropertyName("ColumnType")]
        public string? ColumnType { get; set; }
    }
}