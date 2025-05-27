using System.Collections.Generic;

namespace webapp.ViewModels
{
    public class ServiceCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
    }

    public class ServiceCategoryDetailViewModel : ServiceCategoryViewModel
    {
        public IEnumerable<ServiceViewModel> Services { get; set; } = new List<ServiceViewModel>();
    }
}
