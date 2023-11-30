using IMS.Client.Models;
using System.Net.Http.Json;

namespace IMS.Client.Contracts.Products
{
    public class ProductServices : IProductServices
    {
        private HttpClient _client;

        public ProductServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<IEnumerable<ProductModel>> GetProducts(string productToSearch = "")
        {
            var result = await _client.GetFromJsonAsync<ProductModel[]>("api/Product/ByName?name=" + productToSearch);
            return result;
        }
    }

}
