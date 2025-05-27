using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapp.ViewModels
{
    public class BookingFormViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Full Name")]
        public string ClientName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [Display(Name = "Email Address")]
        public string ClientEmail { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        [Display(Name = "Phone Number")]
        public string ClientPhone { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Service is required")]
        [Display(Name = "Service")]
        public int ServiceId { get; set; }
        
        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        
        [Required(ErrorMessage = "Time slot is required")]
        [Display(Name = "Time Slot")]
        public string TimeSlot { get; set; } = string.Empty;
        
        [Display(Name = "Notes or Special Requests")]
        [MaxLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        public string? Notes { get; set; }
    }

    public class BookingViewModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }

    public class TimeSlotViewModel
    {
        public string Value { get; set; } = string.Empty;
        public string DisplayText { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
