using HotelClassLibrary.Data;
using RoomCleaners.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoomCleaners.Service
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<List<HotelTask>> GetTasksByDepartment(string department)
        {
            return await _context.HotelTask.Where(t => t.Role == department).Where(t => t.Status != "Completed").ToListAsync();
        }

        public async Task UpdateTaskStatus(int taskId, string status)
        {
            var task = await _context.HotelTask.FindAsync(taskId);
            task.Status = status;
            await _context.SaveChangesAsync();
        }
    }
}
