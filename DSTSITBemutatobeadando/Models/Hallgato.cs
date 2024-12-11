using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
namespace DSTSITBemutatobeadando.Models
{
    public class Hallgato
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Név")]
        [JsonPropertyName("Név")]
        public string Nev { get; set; } = null!;

        [BsonElement("Átlag")]
        [JsonPropertyName("Átlag")]
        public double Atlag { get; set; }

        [BsonElement("Képzés")]
        [JsonPropertyName("Képzés")]
        public string Kepzes { get; set; } = null!;

        [BsonElement("Anyja neve")]
        [JsonPropertyName("Anyja neve")]
        public string Anyjanev { get; set; } = null!;
    }
}
