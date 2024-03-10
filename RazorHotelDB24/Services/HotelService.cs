using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;
using System.Data;

namespace RazorHotelDB24.Services
{
    public class HotelService : Connection, IHotelService
    {
        private string queryString = "SELECT Hotel_No, Name, Address from Hotel";

        public bool CreateHotel(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public Hotel DeleteHotel(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotel()
        {
            List<Hotel> hoteller = new List<Hotel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand commmand = new SqlCommand(queryString, connection);
                    commmand.Connection.Open();
                    SqlDataReader reader = commmand.ExecuteReader();
                    while (reader.Read())
                    {
                        int hotelNr = reader.GetInt32("Hotel_No");//.GetInt32(0);
                        string hotelNavn = reader.GetString("Name");
                        string hotelAdr = (string)reader["Address"];
                        Hotel hotel = new Hotel(hotelNr, hotelNavn, hotelAdr);
                        hoteller.Add(hotel);
                    }
                }
                catch (SqlException sqlEx)
                {
                    Console.WriteLine("Database error " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl " + ex.Message);
                }
                finally
                {
                    //her kommer man altid
                }
            }
            return hoteller;
        }

        public Hotel GetHotelFromId(int hotelNr)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetHotelsByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool UpdateHotel(Hotel hotel, int hotelNr)
        {
            throw new NotImplementedException();
        }
    }
}
