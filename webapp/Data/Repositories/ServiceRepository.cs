using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Data.Entities;

namespace webapp.Data.Repositories
{
    public class ServiceRepository : Repository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Service?> GetBySlugAsync(string slug)
        {
            return await _dbSet
                .Include(s => s.Category)
                .FirstOrDefaultAsync(s => s.Slug == slug);
        }

        public async Task<IEnumerable<Service>> GetByCategoryIdAsync(int categoryId)
        {
            return await _dbSet
                .Where(s => s.ServiceCategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Service>> GetByCategorySlugAsync(string categorySlug)
        {
            return await _dbSet
                .Include(s => s.Category)
                .Where(s => s.Category.Slug == categorySlug)
                .ToListAsync();
        }
    }
}
