using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;
using RazorHotelDB24.Services;

namespace RazorHotelDB24.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private IHotelService _hotelService;

        public List<Hotel> Hotels
        {
            get;
            private set;
        }
        public IndexModel(ILogger<IndexModel> logger, IHotelService hservice)
        {
            _logger = logger;
            _hotelService = hservice;
        }

        public void OnGet()
        {
            Hotels = _hotelService.GetAllHotel();
        }
    }
}
