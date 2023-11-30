

using System.ComponentModel.DataAnnotations;

namespace IMS.Client.Models
{

    public class InventoryModel
    {
        public int InventoryId { get; set; }
        [Required(ErrorMessage = "Please enter Inventory Name")]
        public string InventoryName { get; set; } = default!;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be an integer above zero.")]
        public int Quantity { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Price must be an integer above zero.")]
        public double Price { get; set; } 
    }
}
