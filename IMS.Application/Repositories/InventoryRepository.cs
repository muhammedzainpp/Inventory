using Domain;
using FluentValidation;
using IMS.Application.Extensions;
using IMS.Application.InterFaces;
using IMS.Application.Repositories.Dtos;

namespace IMS.Application.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly IAppDbContext _context;
        private readonly IValidator<InvetoryDto> _validator;

        public InventoryRepository(IAppDbContext context,IValidator<InvetoryDto> validator)
        {
            _context = context;
            _validator = validator;
        }
        public async Task<IEnumerable<Inventory>> GetInventoriesByName(string name = "")
        {
            return _context.Inventories.Where(s => s.InventoryName.Contains(name)).ToList();
        }
        public async Task<int> AddInventory(InvetoryDto inventory)
        {
            var inventoryToEdit = await _context.Inventories.FindAsync(inventory.InventoryId);
            if (inventoryToEdit != null)
            {

                var result = await _validator.ValidateAsync(inventory);
                if (result.IsValid)
                {
                   
                    inventoryToEdit.InventoryName = inventory.InventoryName;
                    inventoryToEdit.Quantity = inventory.Quantity;
                    inventoryToEdit.Price = inventory.Price;
                    _context.SaveChanges();
                    return inventoryToEdit.InventoryId;
                }
                else
                 throw new Exception("inventory already exists");    
            }
            else
            {
                var result = await _validator.ValidateAsync(inventory);
                if (!result.IsValid)
                {
                    throw new Exception(" Inventory Already Exist");
                }
                var inventoryToAdd = inventory.ConvertToInventory();
                _context.Inventories.Add(inventoryToAdd);
                _context.SaveChanges();
                return inventoryToAdd.InventoryId;
            }
        }


        

        public async Task<InvetoryDto> GetInvetoryById(int id)
        {
            var inventory = await _context.Inventories.FindAsync(id);
         
                var inventorytoget=inventory?.ConvertToInventoryDto();
                return inventorytoget; 

        }

    }
}