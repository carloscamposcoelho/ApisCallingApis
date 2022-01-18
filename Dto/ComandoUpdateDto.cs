using System.Text.Json.Serialization;

namespace ApisCallingApis.Dto
{
    public class ComandoUpdateDto
    {
        public string Como { get; set; }
        public string Linha { get; set; }
        public string Plataforma { get; set; }
    }
}
