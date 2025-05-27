using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Data.Repositories;
using webapp.ViewModels;

namespace webapp.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<IEnumerable<ServiceViewModel>> GetAllServicesAsync()
        {
            var services = await _serviceRepository.GetAllAsync(s => s.Category);
            
            return services.Select(MapToViewModel).ToList();
        }

        public async Task<ServiceDetailViewModel?> GetServiceBySlugAsync(string slug)
        {
            var service = await _serviceRepository.GetBySlugAsync(slug);
            
            if (service == null)
                return null;
                
            return new ServiceDetailViewModel
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ShortDescription = service.ShortDescription,
                BasePrice = service.BasePrice,
                ImageUrl = service.ImageUrl,
                Slug = service.Slug,
                DurationMinutes = service.DurationMinutes,
                CategoryName = service.Category.Name,
                CategorySlug = service.Category.Slug
            };
        }

        public async Task<IEnumerable<ServiceViewModel>> GetServicesByCategorySlugAsync(string categorySlug)
        {
            var services = await _serviceRepository.GetByCategorySlugAsync(categorySlug);
            
            return services.Select(MapToViewModel).ToList();
        }

        private ServiceViewModel MapToViewModel(Data.Entities.Service service)
        {
            return new ServiceViewModel
            {
                Id = service.Id,
                Name = service.Name,
                ShortDescription = service.ShortDescription,
                BasePrice = service.BasePrice,
                ImageUrl = service.ImageUrl,
                Slug = service.Slug,
                DurationMinutes = service.DurationMinutes,
                CategoryName = service.Category?.Name ?? "Unknown",
                CategorySlug = service.Category?.Slug ?? "unknown"
            };
        }
    }
}
