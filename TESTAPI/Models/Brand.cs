using System.Text.Json.Serialization;

namespace TESTAPI.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string Country { get; set; }
        public string Flag { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
