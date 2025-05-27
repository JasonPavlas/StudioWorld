using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Data.Repositories;
using webapp.ViewModels;

namespace webapp.Services
{
    public class ServiceCategoryService : IServiceCategoryService
    {
        private readonly IServiceCategoryRepository _serviceCategoryRepository;

        public ServiceCategoryService(IServiceCategoryRepository serviceCategoryRepository)
        {
            _serviceCategoryRepository = serviceCategoryRepository;
        }

        public async Task<IEnumerable<ServiceCategoryViewModel>> GetAllCategoriesAsync()
        {
            var categories = await _serviceCategoryRepository.GetAllAsync();
            
            return categories.Select(c => new ServiceCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                ImageUrl = c.ImageUrl,
                Slug = c.Slug
            }).ToList();
        }

        public async Task<ServiceCategoryDetailViewModel?> GetCategoryBySlugAsync(string slug)
        {
            var category = await _serviceCategoryRepository.GetWithServicesBySlugAsync(slug);
            
            if (category == null)
                return null;
                
            return new ServiceCategoryDetailViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                ImageUrl = category.ImageUrl,
                Slug = category.Slug,
                Services = category.Services.Select(s => new ServiceViewModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    ShortDescription = s.ShortDescription,
                    BasePrice = s.BasePrice,
                    ImageUrl = s.ImageUrl,
                    Slug = s.Slug,
                    DurationMinutes = s.DurationMinutes,
                    CategoryName = category.Name,
                    CategorySlug = category.Slug
                }).ToList()
            };
        }
    }
}
