using HotelClassLibrary.Data;
using System.Collections.Generic;

namespace HotelClassLibrary.Services
{
    public class TaskService
    {
        public List<HotelTask> GetRoomTasks(){
            List<HotelTask> tasks = new List<HotelTask>();
            tasks.Add(new HotelTask { Id = 1, Role = "Housekeeping", Description = "Clean room 101", Status = "Pending"});
            tasks.Add(new HotelTask { Id = 2, Role = "Housekeeping", Description = "Clean room 102", Status = "Pending"});
            return tasks;
        }
    }
}