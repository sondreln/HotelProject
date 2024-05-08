namespace HotelProject.Data
{
    public class HotelTask
{
    public int Id { get; set; }

    public required string Role { get; set; } // MAINTAINER, CLEANER, SERVICE
    public string? Description { get; set; }
    public required string Status { get; set; }
}

}