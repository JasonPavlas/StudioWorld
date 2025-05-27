using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using webapp.ViewModels;

namespace webapp.Services
{
    public interface IBookingService
    {
        Task<bool> CreateBookingAsync(BookingFormViewModel model);
        Task<IEnumerable<BookingViewModel>> GetBookingsByClientEmailAsync(string email);
        Task<IEnumerable<TimeSlotViewModel>> GetAvailableTimeSlotsAsync(int serviceId, DateTime date);
    }
}
