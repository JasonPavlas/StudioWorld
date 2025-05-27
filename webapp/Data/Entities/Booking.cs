using System;
using System.Collections.Generic;

namespace webapp.Data.Entities
{
    /// <summary>
    /// Entity representing a client booking in the StudioWorld application
    /// </summary>
    public class Booking : BaseEntity
    {
        public string ClientName { get; set; } = string.Empty;
        public string ClientEmail { get; set; } = string.Empty;
        public string ClientPhone { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        
        // Foreign keys
        public int ServiceId { get; set; }
        
        // Navigation properties
        public Service Service { get; set; } = null!;
    }
    
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Completed,
        Cancelled
    }
}
