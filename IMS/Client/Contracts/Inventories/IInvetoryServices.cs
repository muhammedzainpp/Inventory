using IMS.Client.Models;
using System.Net;

namespace IMS.Client.Contracts.Inventories
{
    public interface IInvetoryServices
    {
        
        Task<int> AddInventory(InventoryModel model);
        Task<IEnumerable<InventoryModel>> GetInventories(string InventoryToSearch);
        Task<InventoryModel> GetInventoryById(int id);
    }
}
