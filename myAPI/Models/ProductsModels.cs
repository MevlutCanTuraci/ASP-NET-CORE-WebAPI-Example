using System.ComponentModel.DataAnnotations;

namespace myAPI.Models
{
    public class ProductsModels
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Price { get; set; }
    }
}
