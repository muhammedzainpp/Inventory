using Domain;
using IMS.Application.Repositories.Dtos;

namespace IMS.Application.Repositories
{
    public interface IInventoryRepository
    {
        
        Task<int> AddInventory(InvetoryDto inventory);
        Task<IEnumerable<Inventory>> GetInventoriesByName(string name = "");
        Task<InvetoryDto> GetInvetoryById(int id);
    }

}

