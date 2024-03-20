using Microsoft.Extensions.FileSystemGlobbing;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace RazorHotelDB24.Models
{
    public class Hotel : IComparable<Hotel>
    {
        [Required(ErrorMessage = "HotelNr er påkrævet")]
        [Range(0, 1000, ErrorMessage = "HotelNr skal være et tal mellem 0 og 1000")]
        public int HotelNr { get; set; }

        [Required(ErrorMessage = "Navn er påkrævet")]
        [StringLength(30, ErrorMessage = "Navn kan højest være 30 karakterer langt")]
        public string Navn { get; set; }

//          ^ markerer starten af strengen.
//          [a-zA-Z]+ matcher én eller flere bogstaver (stor eller lille) i starten af strengen.
//          [\w\d]* matcher nul eller flere bogstaver (stor eller lille), tal eller underscore.Dette giver mulighed for bogstaver, tal eller understregningstegn mellem de indledende bogstaver og det afsluttende tal.
//          \d matcher et enkelt tal.
//          $ markerer slutningen af strengen.

        [Required(ErrorMessage = "Adresse er påkrævet")]
        [StringLength(30, ErrorMessage = "Adresse kan højest være 30 karakterer langt")]
        [RegularExpression(@"^[a-zA-Z]+[\w\d]*\d$", ErrorMessage = "Adresse skal indeholde bogstaver og slutte på et tal")]
        public string Adresse { get; set; }

        public Hotel()
        {
        }

        public Hotel(int hotelNr, string navn, string adresse)
        {
            HotelNr = hotelNr;
            Navn = navn;
            Adresse = adresse;
        }

        public override string ToString()
        {
            return $"{nameof(HotelNr)}: {HotelNr}, {nameof(Navn)}: {Navn}, {nameof(Adresse)}: {Adresse}";
        }

        public int CompareTo(Hotel? other)
        {
            return Navn.CompareTo(other.Navn);
        }
    }
}
