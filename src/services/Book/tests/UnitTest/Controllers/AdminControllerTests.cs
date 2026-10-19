using Xunit;
using Moq;
using Room.Models;
using Book.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace UnitTest.Controllers;

public class AdminControllerTests
{
    [Fact]
    public void Index_should_return_view()
    {
        //Arrange
        var roomsSeeder = new Mock<IRoomsSeeder>();
        var controller = new AdminController(roomsSeeder.Object);

        //Act
        var result = controller.Index();

        //Assert
        Assert.IsType<ViewResult>(result);
    }

    [Fact]
    public async void SeedRooms_should_return_add_rooms_message_when_rooms_were_added()
    {
        //Arrange
        var roomsSeeder = new Mock<IRoomsSeeder>();
        roomsSeeder.Setup(s=>s.EnsurePopulated()).ReturnsAsync(true);

        var controller = new AdminController(roomsSeeder.Object);

        //Act
        var result = await controller.SeedRooms();

        //Assert
        var content = Assert.IsType<ContentResult>(result);
        Assert.Contains("Dodano pokoje",content.Content);
    }
    [Fact]
    public async void SeedRooms_should_return_rooms_already_exist_message_when_rooms_were_added_before()
    {
     //Arrange
     var roomsSeeder = new Mock<IRoomsSeeder>();
     roomsSeeder.Setup(s=>s.EnsurePopulated()).ReturnsAsync(false);

     var controller = new AdminController(roomsSeeder.Object);

     //Act
     var result = await controller.SeedRooms();

     //Assert
     var content = Assert.IsType<ContentResult>(result);
     Assert.Contains("Pokoje już istnieją",content.Content);
    }

}