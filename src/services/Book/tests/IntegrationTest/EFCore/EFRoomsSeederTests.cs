using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Book.Data;
using Room.Models;
using Moq;

namespace IntegrationTest.EFCore;

public class EFRoomsSeederTest
{
    [Fact]
    public async void RoomsSeeder_should_populate_database_principal_rooms()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<BookDbContext>().UseSqlite(connection).Options;

        var context = new BookDbContext(options);

        var roomRepository = new Mock<IRoomRepository>();

        await context.Database.EnsureCreatedAsync();

        var roomSeeder = new RoomsSeeder(roomRepository.Object, context);

        //Act
        var resultFirst = await roomSeeder.EnsurePopulated();
        var resultSecond = await roomSeeder.EnsurePopulated();

        //Assert
        Assert.True(resultFirst);
        Assert.False(resultSecond);
    }
}