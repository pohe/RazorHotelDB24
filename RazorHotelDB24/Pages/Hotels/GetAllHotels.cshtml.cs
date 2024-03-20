using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB24.Helpers;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;

namespace RazorHotelDB24.Pages.Hotels
{
    public class GetAllHotelsModel : PageModel
    {
        
        [BindProperty(SupportsGet = true)]
        public string FilterCriteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrderAscDesc { get; set; }

        public List<Hotel> Hotels
        {
            get;
            private set;
        }

        private IHotelService hotelService;

        public GetAllHotelsModel(IHotelService hService)
        {
            SortOrder = "HotelNr";
            Hotels = new List<Hotel>();
            this.hotelService = hService;
        }

        public void OnGet()
        {
            try
            {
                if (!String.IsNullOrEmpty(FilterCriteria))
                {
                    Hotels = hotelService.GetHotelsByName(FilterCriteria);
                }
                else
                {
                    Hotels = hotelService.GetAllHotel();
                }
                if (SortOrder == "Navn")
                    Hotels.Sort();
                if (SortOrder == "Adresse")
                    Hotels.Sort(new HotelAdresseCompare());
                if (SortOrderAscDesc=="Descending")
                    Hotels.Reverse();
            }
            catch (Exception ex)
            {
                Hotels = new List<Models.Hotel>();
                ViewData["ErrorMessage"] = ex.Message;
            }


        }
    }
}
