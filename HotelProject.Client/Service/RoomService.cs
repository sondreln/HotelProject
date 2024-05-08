using HotelProject.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.Service;

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
}
