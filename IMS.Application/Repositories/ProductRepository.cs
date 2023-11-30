using Domain;
using IMS.Application.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace IMS.Application.Repositories
{
    public class ProductRepository :IProductRepository
    {
        private readonly IAppDbContext _context;

        public ProductRepository(IAppDbContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Product>> GetProductByname(string name = "")
        {
            return  _context.Products.Where(s => s.ProductName.Contains(name)).ToList();
        }
    }

 
}
