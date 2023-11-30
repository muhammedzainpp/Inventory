using Domain;

namespace IMS.Application.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductByname(string name = "");
    }
}