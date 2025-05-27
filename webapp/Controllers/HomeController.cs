using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using webapp.Models;
using webapp.Services;
using webapp.ViewModels;

namespace webapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IServiceCategoryService _serviceCategoryService;
    private readonly IServiceService _serviceService;
    private readonly IMemoryCache _cache;

    public HomeController(
        ILogger<HomeController> logger,
        IServiceCategoryService serviceCategoryService,
        IServiceService serviceService,
        IMemoryCache cache)
    {
        _logger = logger;
        _serviceCategoryService = serviceCategoryService;
        _serviceService = serviceService;
        _cache = cache;
    }

    [ResponseCache(Duration = 60)] // Cache the homepage for 1 minute
    public async Task<IActionResult> Index()
    {
        // Try to get the view model from cache
        if (!_cache.TryGetValue("HomeViewModel", out HomeViewModel? viewModel))
        {
            // If not in cache, build the view model
            viewModel = new HomeViewModel
            {
                ServiceCategories = (await _serviceCategoryService.GetAllCategoriesAsync()).ToList(),
                // Get a few featured services
                FeaturedServices = (await _serviceService.GetAllServicesAsync()).Take(4).ToList()
            };

            // Cache the view model for 1 minute
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(1));
            
            _cache.Set("HomeViewModel", viewModel, cacheOptions);
        }

        return View(viewModel);
    }

    [ResponseCache(Duration = 300)] // Cache the privacy page for 5 minutes
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult HealthCheck()
    {
        return View("~/Views/Shared/HealthCheck.cshtml");
    }
}
