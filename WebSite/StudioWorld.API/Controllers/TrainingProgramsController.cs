using Microsoft.AspNetCore.Mvc;
using StudioWorld.API.Models;

namespace StudioWorld.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainingProgramsController : ControllerBase
{
    private static readonly List<TrainingProgram> _trainingPrograms = new()
    {
        new TrainingProgram
        {
            Id = 1,
            Name = "Content Creation Workshop",
            Description = "Learn the fundamentals of content creation, including video production, photography, editing, and social media strategy. Suitable for beginners and intermediate levels.",
            Duration = "5 days",
            AgeGroups = "12-16 and 17+",
            Price = 250.00M,
            Category = TrainingCategory.ContentCreation
        },
        new TrainingProgram
        {
            Id = 2,
            Name = "Tattoo Artistry Basics",
            Description = "Introduction to tattoo design principles, equipment, safety, and techniques. Practice on synthetic skin and learn from professional tattoo artists.",
            Duration = "5 days",
            AgeGroups = "18+",
            Price = 300.00M,
            Category = TrainingCategory.Tattooing
        },
        new TrainingProgram
        {
            Id = 3,
            Name = "Barbering Fundamentals",
            Description = "Learn basic haircut techniques, styling, and grooming. Practice on mannequins and receive guidance from professional barbers.",
            Duration = "5 days",
            AgeGroups = "14-17 and 18+",
            Price = 200.00M,
            Category = TrainingCategory.Barbering
        },
        new TrainingProgram
        {
            Id = 4,
            Name = "Cosmetology Basics",
            Description = "Introduction to makeup application, skincare, hair styling, and nail care. Learn from licensed cosmetologists in a hands-on environment.",
            Duration = "5 days",
            AgeGroups = "12-16 and 17+",
            Price = 225.00M,
            Category = TrainingCategory.Cosmetology
        },
        new TrainingProgram
        {
            Id = 5,
            Name = "Wellness & Massage Introduction",
            Description = "Learn the basics of therapeutic massage, wellness principles, and self-care practices. Practice basic techniques under professional guidance.",
            Duration = "5 days",
            AgeGroups = "16+ (with parental consent for minors)",
            Price = 175.00M,
            Category = TrainingCategory.MassageTherapy
        }
    };

    [HttpGet]
    public IEnumerable<TrainingProgram> Get()
    {
        return _trainingPrograms;
    }

    [HttpGet("{id}")]
    public ActionResult<TrainingProgram> Get(int id)
    {
        var program = _trainingPrograms.FirstOrDefault(p => p.Id == id);
        if (program == null)
        {
            return NotFound();
        }
        return program;
    }

    [HttpGet("upcoming")]
    public ActionResult<IEnumerable<object>> GetUpcomingSchedule()
    {
        // Sample upcoming training weeks data
        var upcomingSchedule = new List<object>
        {
            new
            {
                Month = "June 2025",
                Dates = "June 9-13",
                RegistrationOpen = true
            },
            new
            {
                Month = "July 2025",
                Dates = "July 14-18",
                RegistrationOpen = false
            },
            new
            {
                Month = "August 2025",
                Dates = "August 11-15",
                RegistrationOpen = false
            }
        };
        
        return upcomingSchedule;
    }
}
