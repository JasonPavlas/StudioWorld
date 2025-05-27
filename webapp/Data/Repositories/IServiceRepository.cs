using webapp.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace webapp.Data.Repositories
{
    public interface IServiceRepository : IRepository<Service>
    {
        Task<Service?> GetBySlugAsync(string slug);
        Task<IEnumerable<Service>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<Service>> GetByCategorySlugAsync(string categorySlug);
    }
}
