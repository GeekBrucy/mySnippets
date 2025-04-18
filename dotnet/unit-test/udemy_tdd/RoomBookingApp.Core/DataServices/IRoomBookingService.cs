using RoomBookingApp.Core.Domain;

namespace RoomBookingApp.Core.DataServices
{
    public interface IRoomBookingService
    {
        void Save(RoomBooking roomBookingApp);

        IEnumerable<Room> GetAvailableRooms(DateTime date);
    }
}