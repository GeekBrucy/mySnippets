using FluentAssertions;
using RoomBookingApp.Core.Models;
using RoomBookingApp.Core.Processors;
using Shouldly;

namespace RoomBookingApp.Core.Tests
{
    public class RoomBookingRequestProcessorTest
    {
        private RoomBookingRequestProcessor _processor;

        public RoomBookingRequestProcessorTest()
        {
            // Arrange
            _processor = new RoomBookingRequestProcessor();
        }
        [Fact]
        public void Should_Return_Room_Booking_Response_With_Request_Values()
        {
            // Arrange
            var bookingRequest = new RoomBookingRequest
            {
                FullName = "Test Name",
                Email = "test@req.com",
                Date = new DateTime(2025, 02, 23)
            };

            // Act
            RoomBookingResult result = _processor.BookRoom(bookingRequest);

            // Assert
            result.Should().NotBeNull();
            result.FullName.Should().Be(bookingRequest.FullName);
            result.Email.Should().Be(bookingRequest.Email);
            result.Date.Should().Be(bookingRequest.Date);
        }

        [Fact]
        public void Should_Throw_Exception_For_Null_Request()
        {
            // Arrange


            // Act
            Action act = () => _processor.BookRoom(null);

            // Assert
            Should.Throw<ArgumentNullException>(act);
            var exception = act.Should().Throw<ArgumentException>();
            exception.Which.ParamName.Should().Be("bookingRequest");
        }
    }
}