using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;
using RazorHotelDB24.Services;

namespace HotelTest
{
    [TestClass]
    public class HotelServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {

        }

        [TestMethod]
        public void TestAddHotel()
        {
            //Arrange
            IHotelService hotelService = new HotelService(true);
            List<Hotel> hotels = hotelService.GetAllHotel();

            //Act
            int numbersOfHotelsBefore = hotels.Count;
            Hotel newHotel = new Hotel(1001, "TestHotel", "Testvej");
            bool ok = hotelService.CreateHotel(newHotel);
            hotels = hotelService.GetAllHotel();

            int numbersOfHotelsAfter = hotels.Count;
            Hotel h = hotelService.DeleteHotel(newHotel.HotelNr);

            //Assert
            Assert.AreEqual(numbersOfHotelsBefore + 1, numbersOfHotelsAfter);
            Assert.IsTrue(ok);
            Assert.AreEqual(h.HotelNr, newHotel.HotelNr);



        }
    }
}