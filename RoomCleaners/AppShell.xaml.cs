namespace RoomCleaners;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(TaskListPage), typeof(TaskListPage));
		Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));

	}
}
