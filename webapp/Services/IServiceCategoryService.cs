using System.Collections.Generic;
using System.Threading.Tasks;
using webapp.Data.Entities;
using webapp.ViewModels;

namespace webapp.Services
{
    public interface IServiceCategoryService
    {
        Task<IEnumerable<ServiceCategoryViewModel>> GetAllCategoriesAsync();
        Task<ServiceCategoryDetailViewModel?> GetCategoryBySlugAsync(string slug);
    }
}
