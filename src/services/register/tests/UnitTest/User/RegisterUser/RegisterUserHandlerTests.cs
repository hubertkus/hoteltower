using Moq;
using User.Models;
using User.RegisterUser;
using User.RegisterUser.Commands;
using User.ValueObjects;

namespace UnitTest.User.RegisterUser;


public class RegisterUserHandlerTests
{

    [Fact]
    public async Task Handle_should_call_AddUser_when_user_does_not_exist()
    {
        //Arrange
        var user = new global::User.Models.User(
         Name.Of("Hubert"),
         Email.Of("hubert@gmail.com"));

        var repositoryMoq = new Mock<IUserRepository>();

        repositoryMoq
            .Setup(x => x.AddUser(It.IsAny<global::User.Models.User>()))
            .ReturnsAsync(user);

        var handler = new RegisterUserHandler(repositoryMoq.Object);

        var command = new RegisterUserCommand("Hubert", "hubert@gmail.com");
        //Act
        await handler.Handle(command, CancellationToken.None);
        //Assert
        repositoryMoq.Verify(x => x.AddUser(It.IsAny<global::User.Models.User>()), Times.Once);
    }

    [Fact]
    public async Task Handle_should_not_call_AddUser_when_user_exist()
    {
        //Arrange
        var user = new global::User.Models.User(
         Name.Of("Hubert"),
         Email.Of("hubert@gmail.com"));

        var repositoryMoq = new Mock<IUserRepository>();

        repositoryMoq
            .Setup(x => x.GetByEmailAsync(It.IsAny<Email>(),It.IsAny<CancellationToken>())).ReturnsAsync(user);

        var handler = new RegisterUserHandler(repositoryMoq.Object);

        var command = new RegisterUserCommand("Hubert", "hubert@gmail.com");
        //Act
        await handler.Handle(command, CancellationToken.None);
        //Assert
        repositoryMoq.Verify(x => x.AddUser(It.IsAny<global::User.Models.User>()), Times.Never);
    }

}