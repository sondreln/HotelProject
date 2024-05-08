using HotelClassLibrary.Models;
using System.Collections.Generic;

namespace HotelClassLibrary.Services
{
    public class TaskService
    {
        public List<RoomTask> GetRoomTasks(){
            List<RoomTask> tasks = new List<RoomTask>();
            tasks.Add(new RoomTask(1, Role.MAINTAIN, "Clean the room", Status.PENDING, ""));
            tasks.Add(new RoomTask(2, Role.CLEANING, "Clean the bathroom", Status.PENDING, ""));
            tasks.Add(new RoomTask(3, Role.SERVICE, "Change the sheets", Status.PENDING, ""));
            return tasks;
        }
    }
}