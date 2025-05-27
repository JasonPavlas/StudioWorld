using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Data.Entities;
using webapp.Data.Repositories;
using webapp.ViewModels;

namespace webapp.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly List<string> _timeSlots;

        public BookingService(IBookingRepository bookingRepository, IServiceRepository serviceRepository)
        {
            _bookingRepository = bookingRepository;
            _serviceRepository = serviceRepository;
            
            // Define standard time slots
            _timeSlots = new List<string>
            {
                "9:00 AM", "10:00 AM", "11:00 AM", "12:00 PM", 
                "1:00 PM", "2:00 PM", "3:00 PM", "4:00 PM", "5:00 PM"
            };
        }

        public async Task<bool> CreateBookingAsync(BookingFormViewModel model)
        {
            // Validate if the service exists
            var service = await _serviceRepository.GetByIdAsync(model.ServiceId);
            if (service == null)
                return false;
                
            // Check if the time slot is available
            var isAvailable = await _bookingRepository.IsTimeSlotAvailableAsync(
                model.ServiceId, 
                model.AppointmentDate, 
                model.TimeSlot);
                
            if (!isAvailable)
                return false;
                
            // Create a new booking entity
            var booking = new Booking
            {
                ClientName = model.ClientName,
                ClientEmail = model.ClientEmail,
                ClientPhone = model.ClientPhone,
                ServiceId = model.ServiceId,
                AppointmentDate = model.AppointmentDate,
                TimeSlot = model.TimeSlot,
                Notes = model.Notes ?? string.Empty,
                Status = BookingStatus.Pending
            };
            
            // Save the booking to the database
            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();
            
            return true;
        }

        public async Task<IEnumerable<BookingViewModel>> GetBookingsByClientEmailAsync(string email)
        {
            var bookings = await _bookingRepository.GetByClientEmailAsync(email);
            
            return bookings.Select(b => new BookingViewModel
            {
                Id = b.Id,
                ClientName = b.ClientName,
                AppointmentDate = b.AppointmentDate,
                TimeSlot = b.TimeSlot,
                ServiceName = b.Service.Name,
                Status = b.Status.ToString()
            }).ToList();
        }

        public async Task<IEnumerable<TimeSlotViewModel>> GetAvailableTimeSlotsAsync(int serviceId, DateTime date)
        {
            // Get all bookings for the service on the specified date
            var bookings = await _bookingRepository.FindAsync(
                b => b.ServiceId == serviceId && 
                     b.AppointmentDate.Date == date.Date && 
                     b.Status != BookingStatus.Cancelled);
                     
            var bookedTimeSlots = bookings.Select(b => b.TimeSlot).ToList();
            
            // Return all time slots with availability information
            return _timeSlots.Select(ts => new TimeSlotViewModel
            {
                Value = ts,
                DisplayText = ts,
                IsAvailable = !bookedTimeSlots.Contains(ts)
            }).ToList();
        }
    }
}
