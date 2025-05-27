using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Data.Entities;

namespace webapp.Data.Repositories
{
    public class ServiceCategoryRepository : Repository<ServiceCategory>, IServiceCategoryRepository
    {
        public ServiceCategoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<ServiceCategory?> GetWithServicesBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(c => c.Services)
                .FirstOrDefaultAsync(c => c.Slug == slug);
        }

        public async Task<IEnumerable<ServiceCategory>> GetAllWithServicesAsync()
        {
            return await _dbSet
                .Include(c => c.Services)
                .ToListAsync();
        }
    }
}
