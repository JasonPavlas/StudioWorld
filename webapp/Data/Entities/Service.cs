using System;
using System.Collections.Generic;

namespace webapp.Data.Entities
{
    /// <summary>
    /// Entity representing a service offered by StudioWorld
    /// </summary>
    public class Service : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public int DurationMinutes { get; set; }
        
        // Foreign keys
        public int ServiceCategoryId { get; set; }
        
        // Navigation properties
        public ServiceCategory Category { get; set; } = null!;
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
