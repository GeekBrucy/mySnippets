using RoomBookingApp.Core.Enums;

namespace RoomBookingApp.Core.Models
{
  public class RoomBookingResult : RoomBookingBase
  {
    public BookingResultFlag Flag { get; set; }
    public object RoomBookingId { get; set; }
  }
}