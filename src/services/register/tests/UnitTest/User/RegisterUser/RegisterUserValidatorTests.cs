using FluentValidation.TestHelper;
using User.RegisterUser;
using User.RegisterUser.Commands;

namespace UnitTest.User.RegisterUser;

public class RegisterUserValidatoTests
{
    private readonly RegisterUserValidator validator = new();
    [Fact]
    public void Should_have_error_when_name_is_empty()
    {
        //Arrange
        var command = new RegisterUserCommand(string.Empty, "hubert@gmail.com");
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldHaveValidationErrorFor(x => x.Name).WithErrorMessage("Name must be not empty");
    }
    [Fact]
    public void Should_have_error_when_email_is_empty()
    {
        //Arrange
        var command = new RegisterUserCommand("Hubert", string.Empty);
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldHaveValidationErrorFor(x => x.Email).WithErrorMessage("Email must be not empty");
    }
    [Fact]
    public void Should_have_no_error_when_name_and_email_are_not_empty()
    {
        //Arrange
        var command = new RegisterUserCommand("Hubert", "hubert@gmail.com");
        //Act
        var result = validator.TestValidate(command);
        //Assert
        result.ShouldNotHaveAnyValidationErrors();
    }
}