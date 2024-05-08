using Microsoft.Maui.Controls;
using HotelClassLibrary.Models;


namespace RoomCleaners
{
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage(RoomTask task)
        {
            InitializeComponent();
            if (task != null)
            {
                DescriptionLabel.Text = task.Description;
                if(task.Status == Status.COMPLETED)
                {
                    StatusLabel.Text = "Completed";
                }
                if(task.Status == Status.INPROGRESS)
                {
                    StatusLabel.Text = "In Progress";
                }
                else
                {
                    StatusLabel.Text = "Not Started";
                }
            }
            else
            {
                DescriptionLabel.Text = "No task information provided.";
            }
        }
    }
}
