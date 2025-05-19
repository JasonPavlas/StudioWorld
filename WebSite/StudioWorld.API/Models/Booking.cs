namespace StudioWorld.API.Models;

public class Booking
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public int ServiceId { get; set; }
    public DateTime AppointmentDateTime { get; set; }
    public string Notes { get; set; } = string.Empty;
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
}

public enum BookingStatus
{
    Pending,
    Confirmed,
    Cancelled,
    Completed
}
