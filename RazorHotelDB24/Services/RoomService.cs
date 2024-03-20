using Microsoft.Data.SqlClient;
using RazorHotelDB24.Interfaces;
using RazorHotelDB24.Models;

namespace RazorHotelDB24.Services
{
    public class RoomService : Connection, IRoomService
    {

        private String queryString = "select * from Room where Hotel_no = @HNo";
        private String queryStringFromID = "select * from Room where Hotel_no = @HNo AND Room_No = @ID";
        private String insertSql = "insert into Room Values (@ID, @HNo, @RType, @RPrice)";
        private String deleteSql = "delete from Room where Hotel_no = @HNo AND Room_No = @ID";
        private String updateSql = "update Room " +
                                   "set Room_No= @RoomID, Types=@RType, Price=@RPris " +
                                   "where Hotel_no = @HNo AND Room_No = @ID";

        public RoomService()
        {
            
        }

        public bool CreateRoom(int hotelNr, Room room)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(insertSql, connection);
                command.Parameters.AddWithValue("@HNo", hotelNr);
                command.Parameters.AddWithValue("@ID", room.RoomNr);
                command.Parameters.AddWithValue("@RType", room.Types);
                command.Parameters.AddWithValue("@RPrice", room.Pris);
                command.Connection.Open();
                int noOfRows = command.ExecuteNonQuery();
                if (noOfRows == 1)
                {
                    return true;
                }
                return false;
            }
        }

        
        public Room DeleteRoom(int roomNr, int hotelNr)
        {
            Room room = GetRoomFromId(roomNr, hotelNr);
            if (room == null)
            {
                return null;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(deleteSql, connection);
                command.Parameters.AddWithValue("@HNo", hotelNr);
                command.Parameters.AddWithValue("@ID", roomNr);
                command.Connection.Open();
                int noOfRows = command.ExecuteNonQuery();
                if (noOfRows == 1)
                {
                    return room;
                }
                return null;
            }
        }

        private Room ReadRoom(SqlDataReader reader)
        {
            int roomNr = reader.GetInt32(0);
            int hotelNr = reader.GetInt32(1);
            String s = reader.GetString(2);
            char roomType = s[0];
            double roomPris = reader.GetDouble(3);
            Room room = new Room(roomNr, roomType, roomPris, hotelNr);
            return room;
        }

        public List<Room> GetAllRoom(int hotelNr)
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@HNo", hotelNr);
                command.Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while ( reader.Read())
                {
                    int roomNr = reader.GetInt32(0);
                    int hotel_nr = reader.GetInt32(1);
                    string types = reader.GetString(2);
                    double price = reader.GetDouble(3);

                    Room room = new Room(roomNr, types[0], price, hotel_nr);
                    rooms.Add(room);
                }
            }
            return rooms;
        }

        public Room GetRoomFromId(int roomNr, int hotelNr)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryStringFromID, connection);
                command.Parameters.AddWithValue("@HNo", hotelNr);
                command.Parameters.AddWithValue("@ID", roomNr);

                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return ReadRoom(reader);
                }
            }
            return null;
        }

        public bool UpdateRoom(Room room, int roomNr, int hotelNr)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(updateSql, connection);
                command.Parameters.AddWithValue("@HNo", hotelNr);
                command.Parameters.AddWithValue("@ID", roomNr);
                command.Parameters.AddWithValue("@RoomID", room.RoomNr);
                command.Parameters.AddWithValue("@RType", room.Types);
                command.Parameters.AddWithValue("@RPris", room.Pris);
                command.Connection.Open();
                int noOfRows = command.ExecuteNonQuery();
                if (noOfRows == 1)
                {
                    return true;
                }
                return false;
            }
        }

        

       

        

       

        
    }
}
