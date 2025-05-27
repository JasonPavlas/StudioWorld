using System;
using System.Collections.Generic;

namespace webapp.Data.Entities
{
    /// <summary>
    /// Entity representing a service category in the StudioWorld application
    /// </summary>
    public class ServiceCategory : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        
        // Navigation properties
        public List<Service> Services { get; set; } = new List<Service>();
    }
}
