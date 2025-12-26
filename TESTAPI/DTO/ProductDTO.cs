namespace TESTAPI.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string AdditionalDescription { get; set; }

        // Vetëm IDs për lidhjet
        public int BrandId { get; set; }
        public int CategoryId { get; set; }

        // Opsionale: emrat për shfaqje
        public string? BrandName { get; set; }
        public string? CategoryName { get; set; }
    }
}
