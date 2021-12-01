using System.ComponentModel.DataAnnotations;

namespace ShopBridge.Model
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage ="Name can only be 20 charecters long")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name can only be 100 charecters long")]
        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

    }
}
