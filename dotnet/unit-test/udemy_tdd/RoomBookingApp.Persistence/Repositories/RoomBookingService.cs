using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;

namespace RoomBookingApp.Persistence.Repositories
{
    public class RoomBookingService : IRoomBookingService
    {
        private readonly RoomBookingAppDbContext _context;
        public RoomBookingService(RoomBookingAppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Room> GetAvailableRooms(DateTime date)
        {
            var availableRooms = _context
                .Rooms
                .Where(r => r.RoomBookings.Any(x => x.Date == date) == false)
                .ToList();

            return availableRooms;
        }

        public void Save(RoomBooking roomBookingApp)
        {
            throw new NotImplementedException();
        }
    }
}