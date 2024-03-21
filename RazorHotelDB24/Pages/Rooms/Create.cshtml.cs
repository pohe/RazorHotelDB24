using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;

namespace RazorHotelDB24.Pages.Rooms
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Room Room { get; set; }// = new Room();

        [BindProperty(SupportsGet = true)]
        public int HotelNr { get; set; }

        [BindProperty]
        public RoomType TheRoomType { get; set; }

        [BindProperty]
        public bool createResult { get; set; }

        IRoomService roomService;

        public CreateModel(IRoomService rService)
        {
            this.roomService = rService;
        }

        public IActionResult OnGet(int id)
        {
            HotelNr = id;
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Room.Types = TheRoomType.ToString()[0];
            createResult = roomService.CreateRoom(HotelNr, Room);
            if (createResult)
                return RedirectToPage("GetAllRooms", "MyRooms", new { cid = HotelNr });
            else
            {
                return Page();
            }


        }
    }
}
