using Moq;
using Booking.Models;
using Booking.RegisterBooking;
using Booking.RegisterBooking.Commands;

namespace UnitTest.Book.RegisterBooking;

public class RegisterBookingHandlerTests
{
    [Fact]
    public async Task RegisterBookingHandler_ShouldCallAddBook_WhenBookDoesNotExist()
    {
        //Arrange
        var repositoryMoq = new Mock<IBookingRepository>();

        repositoryMoq
            .Setup(x => x.GetByBookingAsync(It.IsAny<Guid>(), It.IsAny<DateOnly>(), It.IsAny<DateOnly>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(false);   

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
    public async Task RegisterBookingHandler_ShouldNotCallAddBook_WhenBookExist()
    {
        //Arrange
        var repositoryMoq = new Mock<IBookingRepository>();

        repositoryMoq
            .Setup(x => x.GetByBookingAsync(It.IsAny<Guid>(),It.IsAny<DateOnly>(),It.IsAny<DateOnly>(),It.IsAny<CancellationToken>())).ReturnsAsync(true);

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