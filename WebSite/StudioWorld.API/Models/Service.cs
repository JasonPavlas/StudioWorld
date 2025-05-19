namespace StudioWorld.API.Models;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public ServiceCategory Category { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public enum ServiceCategory
{
    ContentCreation,
    Tattooing,
    Barbershop,
    Cosmetology,
    MassageTherapy
}
