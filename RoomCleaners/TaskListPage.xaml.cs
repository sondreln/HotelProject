using Microsoft.Maui.Controls;
using RoomCleaners.ViewModels;
using HotelClassLibrary.Models;
using System;

namespace RoomCleaners {
    public partial class TaskListPage : ContentPage{

        public TaskListViewModel ViewModel { get; set; }
        public TaskListPage(string role){
            InitializeComponent();
            ViewModel = new TaskListViewModel(role);
        }

        protected override void OnNavigatedTo(NavigatedToEventArgs e){
            base.OnNavigatedTo(e);


        }

            public async void OnViewDetails(object sender, EventArgs e){
                var button = sender as Button;
                var task = button.BindingContext as RoomTask;
                await Shell.Current.GoToAsync($"taskdetailpage?description={task.Description}&status={task.Status}");
        }
    }   
}