namespace RazorHotelDB24.Models
{
    public class Room : IComparable<Room>
    {
        public int RoomNr { get; set; }
        public char Types { get; set; }
        public double Pris { get; set; }

        public int HotelNr { get; set; }

        public Room()
        {

        }
        public Room(int nr, char types, double pris)
        {
            RoomNr = nr;
            Types = types;
            Pris = pris;
        }

        public Room(int nr, char types, double pris, int hotelNr) : this(nr, types, pris)
        {
            HotelNr = hotelNr;
        }

        public override string ToString()
        {
            return $"Room = {RoomNr}, Types = {Types}, Pris = {Pris}";
        }

        public int CompareTo(Room? other)
        {
            if (other == null)
            {
                return 1;
            }

            if (HotelNr != other.HotelNr)
            {
                return HotelNr.CompareTo(other.HotelNr);
            }

            return RoomNr.CompareTo(other.RoomNr);
        }
    }
}
