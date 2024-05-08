namespace HotelProject.Data{
public class Booking {
    public int Id { get; set; }

    public int RoomId { get; set; }

    public DateTime BookedFrom { get; set; }

    public DateTime BookedTo { get; set; }
}
}