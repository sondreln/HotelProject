using System.Collections.ObjectModel;
using System.ComponentModel;
using HotelClassLibrary.Models;
using HotelClassLibrary.Services;


namespace RoomCleaners.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<RoomTask> Tasks { get; set; }
        public TaskService TaskService { get; set; } = new TaskService();

        public TaskListViewModel(string role)
        {
            FetchTasksForRole(role);
        }

        private IEnumerable<Task> FetchTasksForRole(string role)
        {
            Role eRole = Role.MAINTAIN;  
            switch (role)
            {
                case "maintaier":
                    eRole = Role.MAINTAIN;
                    break;
                case "cleaner":
                    eRole = Role.CLEANING;
                    break;
                case "service":
                    eRole = Role.SERVICE;
                    break;
                default:
                    break;
            }
            Tasks = TaskService.GetRoomTasks();
            return (IEnumerable<Task>)Tasks.Where(t => t.Role == eRole).ToList();
            
           
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
