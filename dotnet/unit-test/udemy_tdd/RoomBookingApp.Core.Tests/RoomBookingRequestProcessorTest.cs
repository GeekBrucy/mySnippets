using FluentAssertions;
using Moq;
using RoomBookingApp.Core.DataServices;
using RoomBookingApp.Core.Domain;
using RoomBookingApp.Core.Enums;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;

namespace RoomBookingApp.Core.Tests
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;
        private RoomBookingRequest _request;
        private Mock<IRoomBookingService> _roomBookingServiceMock;
        private List<Room> _availableRooms;

        public RoomBookingRequestProcessorTest()
        {
            // Arrange
            _request = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@req.com",
                Date = new DateTime(2025, 02, 23)
            };

            _availableRooms = new List<Room>()
            {
                new Room { Id = 1, Name = "Room 1" },
                new Room { Id = 2, Name = "Room 2" },
                new Room { Id = 3, Name = "Room 3" }
            };
            _roomBookingServiceMock = new Mock<IRoomBookingService>();
            _roomBookingServiceMock.Setup(x => x.GetAvailableRooms(_request.Date))
                .Returns(_availableRooms);
            _processor = new RoomBookingRequestProcessor(_roomBookingServiceMock.Object);
        }
        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            // Arrange


            // Act
            RoomBookingResult result = _processor.BookRoom(_request);

            // Assert
            result.Should().NotBeNull();
            result.FullName.Should().Be(_request.FullName);
            result.Email.Should().Be(_request.Email);
            result.Date.Should().Be(_request.Date);
            // using shouldly
            result.FullName.ShouldBe(_request.FullName);
            result.Email.ShouldBe(_request.Email);
            result.Date.ShouldBe(_request.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            // Arrange


            // Act
            Action act = () => _processor.BookRoom(null);

            // Assert
            // shouldly
            Should.Throw<ArgumentNullException>(act);
            // fluent assertions
            var exception = act.Should().Throw<ArgumentException>();
            exception.Which.ParamName.Should().Be("bookingRequest");
        }

        [Fact]
        public void Should_Save_Room_Booking_Request()
        {
            // Arrange
            RoomBooking savedBooking = null;
            _roomBookingServiceMock.Setup(x => x.Save(It.IsAny<RoomBooking>()))
                .Callback<RoomBooking>(booking =>
                {
                    savedBooking = booking;
                });

            // Act
            _processor.BookRoom(_request);

            // Assert
            _roomBookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Once);
            savedBooking.ShouldNotBeNull();
            savedBooking.FullName.ShouldBe(_request.FullName);
            savedBooking.Email.ShouldBe(_request.Email);
            savedBooking.Date.ShouldBe(_request.Date);
            savedBooking.RoomId.ShouldBe(_availableRooms.First().Id);
        }

        [Fact]
        public void Should_Not_Save_Room_Booking_Request_If_None_Available()
        {
            // Arrange
            // make sure no rooms are available at the beginning
            _availableRooms.Clear();
            // Act
            _processor.BookRoom(_request);

            // Assert
            _roomBookingServiceMock.Verify(q => q.Save(It.IsAny<RoomBooking>()), Times.Never);
        }

        [Theory]
        [InlineData(BookingResultFlag.Failure, false)]
        [InlineData(BookingResultFlag.Success, true)]
        public void Should_Return_SuccessOrFailure_Flag_In_Result(BookingResultFlag bookingSuccessFlag, bool isAvailable)
        {
            // Arrange
            if (!isAvailable)
            {
                _availableRooms.Clear();
            }
            // Act
            var result = _processor.BookRoom(_request);

            // Assert
            bookingSuccessFlag.ShouldBe(result.Flag);
        }

        [Theory]
        [InlineData(1, true)]
        [InlineData(null, false)]
        public void Should_Return_RoomBookingId_In_Result(int? roomBookingId, bool isAvailable)
        {
            // Arrange
            if (!isAvailable)
            {
                _availableRooms.Clear();
            }
            else
            {

                _roomBookingServiceMock.Setup(x => x.Save(It.IsAny<RoomBooking>()))
                    .Callback<RoomBooking>(booking =>
                    {
                        booking.Id = roomBookingId!.Value;
                    });
            }

            // Act
            var result = _processor.BookRoom(_request);

            // Assert
            result.RoomBookingId.ShouldBe(roomBookingId);
        }
    }
}