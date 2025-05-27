using webapp.Data.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace webapp.Data.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetByServiceIdAsync(int serviceId);
        Task<IEnumerable<Booking>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<IEnumerable<Booking>> GetByClientEmailAsync(string email);
        Task<bool> IsTimeSlotAvailableAsync(int serviceId, DateTime appointmentDate, string timeSlot);
    }
}
