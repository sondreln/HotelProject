using HotelProject.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HotelProject.Service
{
    public class TaskService
    {
        // Async method example with proper return of Task
        public async Task<List<HotelTask>> GetTasksByDepartment(string department)
        {
            // Return task immediately since no actual async operation is performed
            return await Task.FromResult(new List<HotelTask>
            {
                new HotelTask { Description = "Clean Room 101", Status = "New" },
                new HotelTask { Description = "Clean Room 102", Status = "New" }
            });
        }

        public void UpdateTask(HotelTask task)
        {
            // Update task in database
            Console.WriteLine($"Task updated: {task.Description}");
        }
    }
}
