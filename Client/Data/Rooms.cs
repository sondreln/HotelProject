namespace HotelProject.Data
{
   public class Rooms
    {
        public int Id { get; set; }
        public int Romnummer { get; set; }
        public string RomKvalitet { get; set; }
        public decimal PrisPerNatt { get; set; }
        public bool ErLedig { get; set; }
        public int Capacity { get; set; } // Add this line

        // Add other properties as necessary
    }
}