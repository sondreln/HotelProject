using System.ComponentModel;
using System.Windows.Input;

namespace RoomCleaners;

public partial class MainPage :	INotifyPropertyChanged
{
	public MainPage()
	{
		InitializeComponent();
		MaintainerBtn.Clicked += OnRoleSelected;
		CleanerBtn.Clicked += OnRoleSelected;
		ServiceBtn.Clicked += OnRoleSelected;

	}

	
	protected async void OnRoleSelected(object sender, EventArgs e)
{
    try
    {
        var button = sender as Button;
        var role = button.Text.ToLower();
        await Shell.Current.GoToAsync($"tasklistpage?role={role}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Navigation failed: {ex.Message}");
        // Optionally display an error message to the user
    }
}


}

