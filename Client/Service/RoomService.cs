using HotelProject.Data;
using HotelClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.Service
{
    public class RoomService
    {
        private readonly ApplicationDbContext _context;

        public RoomService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Rooms>> GetAvailableRoomsAsync()
        {
            return await _context.Rooms.Where(r => r.ErLedig).ToListAsync();
        }

        public async Task<List<Rooms>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<List<string>> GetRoomTypesAsync()
        {
            return await _context.Rooms
                                 .Select(r => r.RomKvalitet)
                                 .Distinct()
                                 .ToListAsync();
        }

        public async Task<List<Rooms>> SearchRoomsAsync(DateTime startDate, DateTime endDate, string roomType, int numberOfPeople)
        {
            IQueryable<Rooms> query = _context.Rooms;

            // Filter by date availability
            var bookedRooms = _context.Bookings
                                    .Where(b => b.BookedTo >= startDate && b.BookedFrom <= endDate)
                                    .Select(b => b.RoomId)
                                    .Distinct();

            query = query.Where(r => !bookedRooms.Contains(r.Romnummer));

            // Filter by room type, if specified
            if (!string.IsNullOrEmpty(roomType))
            {
                query = query.Where(r => r.RomKvalitet == roomType);
            }

            // Filter by capacity
            if (numberOfPeople > 0)
            {
                query = query.Where(r => r.Capacity >= numberOfPeople);
            }

            return await query.ToListAsync();
        }

        public async Task<bool> BookRoomAsync(int roomId, DateTime startDate, DateTime endDate)
        {
            var newBooking = new Bookings
            {
                RoomId = roomId,
                BookedFrom = startDate,
                BookedTo = endDate
            };

            try
            {
                _context.Bookings.Add(newBooking);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
