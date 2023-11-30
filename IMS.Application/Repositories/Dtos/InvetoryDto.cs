using System.ComponentModel.DataAnnotations;

namespace IMS.Application.Repositories.Dtos
{
    public class InvetoryDto
    {
        
        public int InventoryId { get; set; }
        public string? InventoryName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
