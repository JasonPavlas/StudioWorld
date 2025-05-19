namespace StudioWorld.API.Models;

public class TrainingProgram
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public string AgeGroups { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public TrainingCategory Category { get; set; }
    public bool IsAvailable { get; set; } = true;
}

public enum TrainingCategory
{
    ContentCreation,
    Tattooing,
    Barbering,
    Cosmetology,
    MassageTherapy
}
