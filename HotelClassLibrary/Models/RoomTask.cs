using System.Net;
using HotelProject.Data;

namespace HotelClassLibrary.Models
{
    public class RoomTask
    {
        public int Id {get; set;}

        public Rooms Room { get; set; }
        public Role Role { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public string Notes { get; set; }

        public RoomTask(int Id, Role Role,string Description, Status Status, string Notes){
            this.Id = Id;
            this.Role = Role;
            this.Description = Description;
            this.Status = Status;
            this.Notes = Notes;
        }

    }
}