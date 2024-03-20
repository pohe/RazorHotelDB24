using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB24.Interfaces;

namespace RazorHotelDB24.Pages.Booking
{
    public class AddBookingModel : PageModel
    {
        IHotelService hotelService;
        public AddBookingModel(IHotelService hService, IRoomService rService)
        {
            hotelService = hService;

        }
        public void OnGet()
        {
        }


    }
}
