using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace BabyKusto.SampleServer.Contract
{
    public class KustoMgmtRequestBody
    {
        [JsonPropertyName("csl")]
        public string? Csl { get; set; }

        [JsonPropertyName("db")]
        public string? DB { get; set; }

        [JsonPropertyName("options")]
        public JsonObject? Options { get; set; }
    }
}