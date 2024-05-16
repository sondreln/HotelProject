using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Reseptionistas.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using HotelClassLibrary.Data;

namespace Reseptionistas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly TaskService _taskService;

        public List<HotelTask> Tasks { get; set; }

        public IndexModel(ILogger<IndexModel> logger, TaskService taskService)
        {
            _logger = logger;
            _taskService = taskService;
        }

        public async Task OnGetAsync()
        {
            await FetchTasksAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var description = Request.Form["Description"];
            var role = Request.Form["Role"];

            if (string.IsNullOrEmpty(description) || string.IsNullOrEmpty(role))
            {
                ModelState.AddModelError(string.Empty, "Description and Role are required.");
                await FetchTasksAsync(); // Ensure the tasks are fetched even if the model state is invalid
                return Page();
            }

            var newTask = new HotelTask
            {
                Id = 0, // Auto-generated
                Description = description,
                Role = role,
                Status = "Pending" // Default status
            };

            await _taskService.AddTaskAsync(newTask);
            return RedirectToPage("Index");
        }

        private async Task FetchTasksAsync()
        {
            Tasks = await _taskService.GetAllTasks();
        }
    }
}
