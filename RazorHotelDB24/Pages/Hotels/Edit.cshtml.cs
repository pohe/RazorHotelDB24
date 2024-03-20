using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;

namespace RazorHotelDB24.Pages.Hotels
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Hotel HotelToUpdate { get; set; }

        private IHotelService _hotelService;
        public EditModel(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        public void OnGet(int hotelnr)
        {
            HotelToUpdate =  _hotelService.GetHotelFromId(hotelnr);

        }

        public IActionResult OnPost(int hotelNr)
        {
            bool ok =  _hotelService.UpdateHotel(HotelToUpdate, hotelNr);
            if (ok)
            {
                return RedirectToPage("GetAllHotels");
            }
            else
                return Page();
        }
    }
}
