using Moq;
using Booking.Models;
using Booking.RegisterBooking;
using Booking.RegisterBooking.Commands;

namespace UnitTest.Book.RegisterBooking;

public class RegisterBookingHandlerTests
{
    [Fact]
    public async Task Handle_should_call_AddBook_when_book_does_not_exist()
    {
        //Arrange
        var booking = new global::Booking.Models.Booking(
         Guid.NewGuid(),
         Guid.NewGuid(),
         DateOnly.FromDateTime(DateTime.Now),
         DateOnly.FromDateTime(DateTime.Now.AddDays(1)));

        var repositoryMoq = new Mock<IBookingRepository>();

        repositoryMoq
            .Setup(x => x.AddBook(It.IsAny<global::Booking.Models.Booking>()))
            .ReturnsAsync(booking);

        var handler = new RegisterBookingHandler(repositoryMoq.Object);

        var command = new RegisterBookingCommand(
         Guid.NewGuid(),
         Guid.NewGuid(),
         DateOnly.FromDateTime(DateTime.Now),
         DateOnly.FromDateTime(DateTime.Now.AddDays(2)));

        //Act
        await handler.Handle(command, CancellationToken.None);
        
        //Assert
        repositoryMoq.Verify(x => x.AddBook(It.IsAny<global::Booking.Models.Booking>()), Times.Once);
    }

    [Fact]
    public async Task Handle_should_not_call_AddBook_when_book_exist()
    {
        //Arrange
        var booking = new global::Booking.Models.Booking(
         Guid.NewGuid(),
         Guid.NewGuid(),
         DateOnly.FromDateTime(DateTime.Now),
         DateOnly.FromDateTime(DateTime.Now.AddDays(1)));

        var repositoryMoq = new Mock<IBookingRepository>();

        repositoryMoq
            .Setup(x => x.GetByBookingAsync(It.IsAny<Guid>(),It.IsAny<DateOnly>(),It.IsAny<DateOnly>(),It.IsAny<CancellationToken>())).ReturnsAsync(booking);

        var handler = new RegisterBookingHandler(repositoryMoq.Object);

        var command = new RegisterBookingCommand(
         Guid.NewGuid(),
         Guid.NewGuid(),
         DateOnly.FromDateTime(DateTime.Now),
         DateOnly.FromDateTime(DateTime.Now.AddDays(2)));

        //Act
        await handler.Handle(command, CancellationToken.None);

        //Assert
        repositoryMoq.Verify(x => x.AddBook(It.IsAny<global::Booking.Models.Booking>()), Times.Never);
    }
}