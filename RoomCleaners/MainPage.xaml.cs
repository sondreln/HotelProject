using System.ComponentModel;
using System.Windows.Input;
using HotelClassLibrary.Data;
using RoomCleaners.Service;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoomCleaners
{
    public partial class MainPage : INotifyPropertyChanged
    {
        private string _role = "";
        private TaskService _taskService;

        public ObservableCollection<HotelTask> Tasks { get; set; } = new ObservableCollection<HotelTask>();

        public MainPage()
        {
            InitializeComponent();
            _taskService = new TaskService(); // Initialize TaskService here
            MaintainerBtn.Clicked += OnRoleSelected;
            CleanerBtn.Clicked += OnRoleSelected;
            ServiceBtn.Clicked += OnRoleSelected;
        }

        protected void OnRoleSelected(object sender, EventArgs e)
        {
            var role = ((Button)sender).Text;
            _role = role;
            LoadTasks(role);
        }

        protected async void CompleteTask(object sender, EventArgs e)
        {
            var task = (HotelTask)((Button)sender).BindingContext;
            await _taskService.UpdateTaskStatus(task.Id, "Completed");
            LoadTasks(_role);
        }
        private async void LoadTasks(string role)
        {
            Console.WriteLine(role);
            ResultText.Text = $"Selected Role: {role.ToLower()}";
            TaskList.ItemsSource = await GetTasksByDepartment(role.ToLower());

        }


        private async Task<IEnumerable<HotelTask>> GetTasksByDepartment(string department)
        {
            // Await the task service call
            return await Task.Run(() => _taskService.GetTasksByDepartment(department));
        }

        // Use the new keyword to hide the inherited member
        public new event PropertyChangedEventHandler? PropertyChanged;
    }
}
