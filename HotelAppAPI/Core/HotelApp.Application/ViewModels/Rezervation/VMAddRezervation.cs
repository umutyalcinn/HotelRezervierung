
namespace HotelApp.Application.ViewModels.Rezervation
{
    public class VMAddRezervation
    {
        public int CustomerId { get; set ; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
