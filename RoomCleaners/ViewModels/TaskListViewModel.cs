using System.Collections.ObjectModel;
using System.ComponentModel;
using HotelClassLibrary.Data;
using HotelClassLibrary.Services;


namespace RoomCleaners.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public IEnumerable<HotelTask> Tasks { get; set; }
        public TaskService TaskService { get; set; } = new TaskService();

        public TaskListViewModel(string role)
        {
        }

        

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
