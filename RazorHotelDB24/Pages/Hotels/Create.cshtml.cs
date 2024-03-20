using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;

namespace RazorHotelDB24.Pages.Hotels
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Hotel Hotel { get; set; }

        private IHotelService hservice;
        public CreateModel(IHotelService hotelService)
        {
            hservice = hotelService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Hvis valideringen mislykkes, kan du returnere siden med fejlmeddelelser
                return Page();
            }
            try
            {
                hservice.CreateHotel(Hotel);
                return RedirectToPage("GetAllHotels");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }
            return Page();
        }
    }
}
