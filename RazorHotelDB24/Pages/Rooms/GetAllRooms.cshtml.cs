using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;
using System.Security.Cryptography;

namespace RazorHotelDB24.Pages.Rooms
{
    public class GetAllRoomsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int MaxPrice { get; set; }
        public List<Room> Rooms { get; private set; }

        [BindProperty(SupportsGet = true)]
        public string TheRoomType {  get; set; }

        [BindProperty(SupportsGet =true)]
        public string SortOrderAscDesc { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Hotel_nr { get; set; }

        IRoomService roomService;
        public GetAllRoomsModel(IRoomService service)
        {
            this.roomService = service;
        }

        public void OnGet()
        {
            Rooms = roomService.GetAllRoom(Hotel_nr);
            FilterRooms();
        }

        public  void OnGetMyRooms(int cid)
        {
            Hotel_nr = cid;
            OnGet();
        }

        private void FilterRooms()
        {
            if (MaxPrice > 0)
            {
                Rooms = Rooms.FindAll(r => r.Pris <= MaxPrice);
            }

            if (!TheRoomType.IsNullOrEmpty() && TheRoomType != "All")
            {
                RoomType roomType = (RoomType)Enum.Parse(typeof(RoomType), TheRoomType);
                Rooms = Rooms.FindAll(r => r.Types == roomType.ToString()[0]);
            }

            if (SortOrderAscDesc == "Descending")
            {
                Rooms.Reverse();
            }
            else
            {
                Rooms.Sort();
            }
        }

        public IActionResult OnPostDelete(int rid, int hid)
        {
            roomService.DeleteRoom(rid, hid);
            Rooms = roomService.GetAllRoom(hid);
            return Page();
        }
    }
}
