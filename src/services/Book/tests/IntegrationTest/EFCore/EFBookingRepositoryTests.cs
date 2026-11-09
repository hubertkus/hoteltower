using Microsoft.EntityFrameworkCore.Sqlite;
using Room.Models;
using Book.Data;
using Booking.Models;
using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTest.EFCore;

public class EFBookingRepositoryTests
{
    [Fact]
    public async Task GetByBookingAsync_ShouldReturnTrue_when_BookingExist()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<BookDbContext>().UseSqlite(connection).Options;

        await using var context = new BookDbContext(options);

        await context.Database.EnsureCreatedAsync();

        var booking = new global::Booking.Models.Booking(Guid.NewGuid(), Guid.NewGuid(), DateOnly.FromDateTime(new DateTime(2026, 11, 1)), DateOnly.FromDateTime(new DateTime(2026, 11, 3)));

        await context.AddAsync(booking);
        await context.SaveChangesAsync();

        var repository = new EFBookingRepository(context);

        //Act
        var result = await repository.GetByBookingAsync(booking.RoomId, booking.From, booking.To, CancellationToken.None);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task GetByBookingAsync_ShouldReturnFalse_when_BookingNotExist()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<BookDbContext>().UseSqlite(connection).Options;

        await using var context = new BookDbContext(options);

        await context.Database.EnsureCreatedAsync();

        var booking = new global::Booking.Models.Booking(Guid.NewGuid(), Guid.NewGuid(), DateOnly.FromDateTime(new DateTime(2026, 11, 1)), DateOnly.FromDateTime(new DateTime(2026, 11, 3)));

        await context.AddAsync(booking);
        await context.SaveChangesAsync();

        var repository = new EFBookingRepository(context);

        //Act
        var result = await repository.GetByBookingAsync(booking.RoomId, DateOnly.FromDateTime(new DateTime(2026, 11, 4)), DateOnly.FromDateTime(new DateTime(2026, 11, 6)), CancellationToken.None);

        //Assert
        Assert.False(result);
    }

    [Fact]
    public async Task GetByBookingAsync_ShouldReturnTrue_when_BookingContainedTerm()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<BookDbContext>().UseSqlite(connection).Options;

        await using var context = new BookDbContext(options);

        await context.Database.EnsureCreatedAsync();

        var booking = new global::Booking.Models.Booking(Guid.NewGuid(), Guid.NewGuid(), DateOnly.FromDateTime(new DateTime(2026, 11, 1)), DateOnly.FromDateTime(new DateTime(2026, 11, 3)));

        await context.AddAsync(booking);
        await context.SaveChangesAsync();

        var repository = new EFBookingRepository(context);

        //Act
        var result = await repository.GetByBookingAsync(booking.RoomId, DateOnly.FromDateTime(new DateTime(2026, 11, 2)), DateOnly.FromDateTime(new DateTime(2026, 11, 6)), CancellationToken.None);

        //Assert
        Assert.True(result);
    }

    [Fact]
    public async Task AddBook_ShouldReturnBooking_And_WriteBookingToDatabase()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<BookDbContext>().UseSqlite(connection).Options;

        await using var context = new BookDbContext(options);

        await context.Database.EnsureCreatedAsync();

        var booking = new global::Booking.Models.Booking(Guid.NewGuid(), Guid.NewGuid(), DateOnly.FromDateTime(new DateTime(2026, 11, 1)), DateOnly.FromDateTime(new DateTime(2026, 11, 3)));

        var repository = new EFBookingRepository(context);

        //Act
        var result = await repository.AddBook(booking);
        var savedBooking = await context.Bookings.FirstOrDefaultAsync(b => b.UserId == booking.UserId && b.RoomId == booking.RoomId && b.From == booking.From && b.To == booking.To);

        //Assert
        Assert.NotNull(savedBooking);
        Assert.Equal(savedBooking.UserId, result.UserId);
        Assert.Equal(savedBooking.RoomId, result.RoomId);
        Assert.Equal(savedBooking.From, result.From);
        Assert.Equal(savedBooking.To, result.To);

        Assert.NotNull(result);
        Assert.Equal(booking.UserId, result.UserId);
        Assert.Equal(booking.RoomId, result.RoomId);
        Assert.Equal(booking.From, result.From);
        Assert.Equal(booking.To, result.To);
    }
}