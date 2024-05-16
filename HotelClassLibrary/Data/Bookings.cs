namespace HotelClassLibrary.Data{
public class Bookings
{
    public int Id { get; set; }
    public int RoomId { get; set; }
    public DateTime BookedFrom { get; set; }
    public DateTime BookedTo { get; set; }
    public bool CheckedIn { get; set; }
}}