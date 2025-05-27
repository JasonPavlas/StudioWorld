using System.Collections.Generic;
using webapp.ViewModels;

namespace webapp.ViewModels
{
    public class HomeViewModel
    {
        public List<ServiceCategoryViewModel> ServiceCategories { get; set; } = new List<ServiceCategoryViewModel>();
        public List<ServiceViewModel> FeaturedServices { get; set; } = new List<ServiceViewModel>();
    }
}
