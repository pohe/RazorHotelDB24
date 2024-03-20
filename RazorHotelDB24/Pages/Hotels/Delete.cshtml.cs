using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;

namespace RazorHotelDB24.Pages.Hotels
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public Hotel HotelToDelete { get; set; }

        private IHotelService _hotelService;
        public DeleteModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public async Task OnGet(int hotelnr)
        {
            HotelToDelete =  _hotelService.GetHotelFromId(hotelnr);

        }

        public IActionResult OnPost(int hotelNr)
        {
            Hotel deletedhotel = _hotelService.DeleteHotel(hotelNr);
            if (deletedhotel != null)
            {
                return RedirectToPage("GetAllHotels");
            }
            else
                return Page();
        }
    }
}

