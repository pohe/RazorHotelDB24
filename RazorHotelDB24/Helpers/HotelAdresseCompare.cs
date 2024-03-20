using RazorHotelDB24.Models;

namespace RazorHotelDB24.Helpers
{
    public class HotelAdresseCompare : IComparer<Hotel>
    {
        public int Compare(Hotel? x, Hotel? y)
        {
            if (x == null && y == null)
                return 0;
            else if (x == null)
                return -1;
            else if (y == null)
                return 1;

            return string.Compare(x.Adresse, y.Adresse);
        }
    }
}
