using Microsoft.AspNetCore.Mvc;
using StudioWorld.API.Models;

namespace StudioWorld.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private static readonly List<Service> _services = new()
    {
        new Service
        {
            Id = 1,
            Name = "Professional Photography Session",
            Description = "High-quality photography session for personal or business needs.",
            Category = ServiceCategory.ContentCreation,
            Price = 150.00M,
            ImageUrl = "/images/services/photography.jpg"
        },
        new Service
        {
            Id = 2,
            Name = "Video Production",
            Description = "Full-service video production for commercials, events, or social media.",
            Category = ServiceCategory.ContentCreation,
            Price = 500.00M,
            ImageUrl = "/images/services/video.jpg"
        },
        new Service
        {
            Id = 3,
            Name = "Custom Tattoo Design",
            Description = "Custom tattoo design by our experienced artists.",
            Category = ServiceCategory.Tattooing,
            Price = 200.00M,
            ImageUrl = "/images/services/tattoo.jpg"
        },
        new Service
        {
            Id = 4,
            Name = "Premium Haircut",
            Description = "Premium haircut and styling by our expert barbers.",
            Category = ServiceCategory.Barbershop,
            Price = 40.00M,
            ImageUrl = "/images/services/haircut.jpg"
        },
        new Service
        {
            Id = 5,
            Name = "Facial Treatment",
            Description = "Rejuvenating facial treatment for all skin types.",
            Category = ServiceCategory.Cosmetology,
            Price = 85.00M,
            ImageUrl = "/images/services/facial.jpg"
        },
        new Service
        {
            Id = 6,
            Name = "Deep Tissue Massage",
            Description = "60-minute deep tissue massage for stress relief and muscle recovery.",
            Category = ServiceCategory.MassageTherapy,
            Price = 75.00M,
            ImageUrl = "/images/services/massage.jpg"
        }
    };

    [HttpGet]
    public IEnumerable<Service> Get()
    {
        return _services;
    }

    [HttpGet("{id}")]
    public ActionResult<Service> Get(int id)
    {
        var service = _services.FirstOrDefault(s => s.Id == id);
        if (service == null)
        {
            return NotFound();
        }
        return service;
    }

    [HttpGet("category/{category}")]
    public IEnumerable<Service> GetByCategory(ServiceCategory category)
    {
        return _services.Where(s => s.Category == category);
    }
}
