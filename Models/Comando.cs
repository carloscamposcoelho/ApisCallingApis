using System.Text.Json.Serialization;

namespace ApisCallingApis.Models
{
    public class Comando
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("howTo")]
        public string Como { get; set; }
        [JsonPropertyName("line")]
        public string Linha { get; set; }
        [JsonPropertyName("platform")]
        public string Plataforma { get; set; }
    }
}
