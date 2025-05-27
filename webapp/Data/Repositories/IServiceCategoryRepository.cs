using webapp.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace webapp.Data.Repositories
{
    public interface IServiceCategoryRepository : IRepository<ServiceCategory>
    {
        Task<ServiceCategory?> GetWithServicesBySlugAsync(string slug);
        Task<IEnumerable<ServiceCategory>> GetAllWithServicesAsync();
    }
}
