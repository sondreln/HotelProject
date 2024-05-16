using HotelClassLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Reseptionistas.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reseptionistas.Service
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<HotelTask>> GetTasksByDepartment(string department)
        {
            return await _context.HotelTask.Where(t => t.Role == department).ToListAsync();
        }

        public async Task<List<HotelTask>> GetAllTasks()
        {
            return await _context.HotelTask.ToListAsync();
        }

        public async Task UpdateTaskStatus(int taskId, string status)
        {
            var task = await _context.HotelTask.FindAsync(taskId);
            if (task != null)
            {
                task.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddTaskAsync(HotelTask task)
        {
            _context.HotelTask.Add(task);
            await _context.SaveChangesAsync();
        }
    }
}
