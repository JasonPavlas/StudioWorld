using System.Collections.Generic;
using System.Threading.Tasks;
using webapp.ViewModels;

namespace webapp.Services
{
    public interface IServiceService
    {
        Task<IEnumerable<ServiceViewModel>> GetAllServicesAsync();
        Task<ServiceDetailViewModel?> GetServiceBySlugAsync(string slug);
        Task<IEnumerable<ServiceViewModel>> GetServicesByCategorySlugAsync(string categorySlug);
    }
}
