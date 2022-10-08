using System.Text.Json.Serialization;

namespace BabyKusto.SampleServer.Contract
{
    public class KustoApiResult
    {
        [JsonPropertyName("Tables")]
        public List<KustoApiTableResult> Tables { get; } = new();
    }
}