using IMS.Client.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace IMS.Client.Contracts.Inventories
{
    public class InventoryServices : IInvetoryServices
    {
        private readonly HttpClient _client;

        public InventoryServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<InventoryModel>> GetInventories(string InventoryToSearch="")
        {
            var result = await _client.GetFromJsonAsync<InventoryModel[]>("api/Inventory/ByName?name="+InventoryToSearch);
            return result;
        }

        public async Task<InventoryModel> GetInventoryById(int id)
        {
            var result = await _client.GetFromJsonAsync<InventoryModel>("api/Inventory/ById?id=" + id);
            return result;
        }

        public async Task<int> AddInventory(InventoryModel model)
         

        {

            var response = await _client.PostAsJsonAsync("api/Inventory/AddInventory", model);
            if(!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
            else
            {
                return (int)response.StatusCode;
            }    
           
        }
       
    }
}
