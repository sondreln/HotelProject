namespace HotelClassLibrary.Data
{
    public class Rooms
    {
        public int Id { get; set; }
        public int Romnummer { get; set; }
        public int Capacity { get; set; }
        public bool ErLedig { get; set; }
        public int PrisPerNatt { get; set; }
        public string? RomKvalitet { get; set; }

    }
}