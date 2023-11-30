using Domain;
using IMS.Application.Repositories.Dtos;

namespace IMS.Application.Extensions
{
    public static class InventoryExtensions
    {
        public static Inventory ConvertToInventory(this InvetoryDto inventory)
        {
          var newInventory= new Inventory()
          {
              InventoryName=inventory.InventoryName,
              Quantity=inventory.Quantity,
              Price=inventory.Price
          };
            return newInventory;
        }

        public static InvetoryDto ConvertToInventoryDto(this Inventory inventory)
        {
            var newInventory = new InvetoryDto()
            {
                InventoryId=inventory.InventoryId,  
                InventoryName = inventory.InventoryName,
                Quantity = inventory.Quantity,
                Price = inventory.Price
            };
            return newInventory;
        }
    }
}
