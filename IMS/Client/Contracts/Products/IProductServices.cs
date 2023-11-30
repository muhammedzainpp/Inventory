using IMS.Client.Models;

namespace IMS.Client.Contracts.Products
{
    public interface IProductServices
    {
        Task<IEnumerable<ProductModel>> GetProducts(string productToSearch = "");
    }
}