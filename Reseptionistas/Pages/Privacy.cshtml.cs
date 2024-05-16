using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HotelClassLibrary.Data;
using Reseptionistas.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reseptionistas.Pages
{
    public class CheckerModel : PageModel
    {
        private readonly ILogger<CheckerModel> _logger;
        private readonly BookingService _bookingService;

      
        public List<Bookings> Bookings { get; set; }

        public CheckerModel(ILogger<CheckerModel> logger, BookingService bookingService)
        {
            _logger = logger;
            _bookingService = bookingService;
        }

        public async Task OnGetAsync()
        {
            await FetchBookingsAsync();
        }

        public async Task FetchBookingsAsync()
        {
            Bookings = await _bookingService.GetAllBookings();
        }

        public async Task<IActionResult> OnPostCheckInAsync(int id)
        {
            await _bookingService.CheckInAsync(id);
            FetchBookingsAsync();
            return RedirectToPage("Privacy");
        }

        public async Task<IActionResult> OnPostCheckOutAsync(int id)
        {
            await _bookingService.CheckOutAsync(id);
            FetchBookingsAsync();
            return RedirectToPage("Privacy");
        }
    }
}