using HotelClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Reseptionistas.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reseptionistas.Service
{
    public class BookingService{
        private readonly ApplicationDbContext _context;

        public BookingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bookings>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task CheckInAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            booking.CheckedIn = true;
            await _context.SaveChangesAsync();
        }

        public async Task CheckOutAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            booking.CheckedIn = false;
            await _context.SaveChangesAsync();
        }

        public async Task AddBookingAsync(Bookings booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }
    }
}
