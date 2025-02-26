
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Enums;
using RoomBookingApp.Core.Models;

namespace RoomBookingApp.Core.Processors
{
  public class RoomBookingRequestProcessor : IRoomBookingRequestProcessor
  {
    private IRoomBookingService _roomBookingService;

    public RoomBookingRequestProcessor()
    {
    }

    private TRoomBooking CreateRoomBookingObject<TRoomBooking>(RoomBookingRequest request)
    where TRoomBooking : RoomBookingBase, new()
    {
      return new TRoomBooking
      {
        FullName = request.FullName,
        Email = request.Email,
        Date = request.Date
      };
    }

    public RoomBookingRequestProcessor(IRoomBookingService roomBookingService)
    {
      _roomBookingService = roomBookingService;
    }

    public RoomBookingResult BookRoom(RoomBookingRequest bookingRequest)
    {
      if (bookingRequest is null)
      {
        throw new ArgumentNullException(nameof(bookingRequest));
      }
      var availableRooms = _roomBookingService.GetAvailableRooms(bookingRequest.Date);
      var result = CreateRoomBookingObject<RoomBookingResult>(bookingRequest);
      if (availableRooms.Any())
      {
        var room = availableRooms.First();
        var roomBooking = CreateRoomBookingObject<RoomBooking>(bookingRequest);
        roomBooking.RoomId = room.Id;
        _roomBookingService.Save(roomBooking);
        result.Flag = BookingResultFlag.Success;
        result.RoomBookingId = roomBooking.Id;
      }
      else
      {
        result.Flag = BookingResultFlag.Failure;
      }

      return result;
    }
  }
}