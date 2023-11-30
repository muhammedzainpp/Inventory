using Domain;
using Microsoft.EntityFrameworkCore;

namespace IMS.Application.InterFaces
{

    public interface IAppDbContext
        {
            DbSet<Inventory> Inventories { get; set; }
        DbSet<Product> Products { get; set; }

        int SaveChanges();

            Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
    }
    
}

