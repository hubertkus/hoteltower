using FluentValidation.TestHelper;
using Booking.RegisterBooking;
using Booking.RegisterBooking.Commands;

namespace UnitTest.Book.RegisterBooking;

public class RegisterBookingValidatorTests
{
    private readonly RegisterBookingValidator validator = new();
    [Fact]
    public void Should_have_error_when_userid_is_empty()
    {
        //Arrange
        var command = new RegisterBookingCommand(Guid.Empty, Guid.NewGuid(),DateOnly.FromDateTime(DateTime.Now),DateOnly.FromDateTime(DateTime.Now));
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldHaveValidationErrorFor(x => x.UserId).WithErrorMessage("UserId must be a valid GUID");
    }
    [Fact]
    public void Should_have_error_when_roomid_is_empty()
    {
        //Arrange
        var command = new RegisterBookingCommand(Guid.NewGuid(), Guid.Empty,DateOnly.FromDateTime(DateTime.Now),DateOnly.FromDateTime(DateTime.Now));
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldHaveValidationErrorFor(x => x.RoomId).WithErrorMessage("RoomId must be a valid GUID");
    }
    [Fact]
    public void Should_have_no_error_when_from_date_is_beyond_to_date()
    {
        //Arrange
        var command = new RegisterBookingCommand(Guid.NewGuid(), Guid.NewGuid(), DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now.AddDays(-1)));
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldHaveValidationErrorFor(x => x.From).WithErrorMessage("From date must be before To date");
    }}