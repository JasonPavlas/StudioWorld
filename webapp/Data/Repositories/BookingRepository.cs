using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webapp.Data.Entities;

namespace webapp.Data.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Booking>> GetByServiceIdAsync(int serviceId)
        {
            return await _dbSet
                .Include(b => b.Service)
                .Where(b => b.ServiceId == serviceId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            return await _dbSet
                .Include(b => b.Service)
                .Where(b => b.AppointmentDate >= start && b.AppointmentDate <= end)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetByClientEmailAsync(string email)
        {
            return await _dbSet
                .Include(b => b.Service)
                .Where(b => b.ClientEmail == email)
                .ToListAsync();
        }

        public async Task<bool> IsTimeSlotAvailableAsync(int serviceId, DateTime appointmentDate, string timeSlot)
        {
            // Check if there is any booking with the same service, date and time slot
            var existingBooking = await _dbSet
                .FirstOrDefaultAsync(b => 
                    b.ServiceId == serviceId && 
                    b.AppointmentDate.Date == appointmentDate.Date && 
                    b.TimeSlot == timeSlot &&
                    b.Status != BookingStatus.Cancelled);
                
            // If no booking is found, the time slot is available
            return existingBooking == null;
        }
    }
}
