using BackendTest.API.Shered;
using System.Text.Json.Serialization;

namespace BackendTest.API.Models
{
    public class ProductModel
    {
        public Guid? Id { get; set; }
        [JsonPropertyName("description")]
        public string? Name { get; set; }


        public bool IsNull() { return Name == null; }
    }
}
