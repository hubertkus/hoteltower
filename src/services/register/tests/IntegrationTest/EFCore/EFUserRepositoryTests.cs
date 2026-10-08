using Microsoft.EntityFrameworkCore.Sqlite;
using User.Models;
using Register.Data;
using System.Reflection.Metadata;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using User.ValueObjects;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTest.EFCore;

public class EFUserRepositoryTests
{
    [Fact]
    public async Task GetByEmailAsync_should_return_user_when_email_exists()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<RegisterDbContext>().UseSqlite(connection).Options;

        await using var context = new RegisterDbContext(options);

        await context.Database.EnsureCreatedAsync();

        var user = new global::User.Models.User(Name.Of("Hubert"), Email.Of("hubert@gmail.com"));

        await context.AddAsync(user);
        await context.SaveChangesAsync();

        var repository = new EFUserRepository(context);

        //Act
        var result = await repository.GetByEmailAsync(Email.Of("hubert@gmail.com"), CancellationToken.None);

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Hubert", result.Name.Value);
        Assert.Equal("hubert@gmail.com", result.Email.Value);
    }

    [Fact]
    public async Task GetByEmailAsync_should_return_null_when_email_not_exist()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<RegisterDbContext>().UseSqlite(connection).Options;

        await using var context = new RegisterDbContext(options);

        await context.Database.EnsureCreatedAsync();

        var user = new global::User.Models.User(Name.Of("Hubert"), Email.Of("hubert@gmail.com"));

        await context.AddAsync(user);
        await context.SaveChangesAsync();

        var repository = new EFUserRepository(context);

        //Act
        var result = await repository.GetByEmailAsync(Email.Of("gosia@gmail.com"), CancellationToken.None);

        //Assert
        Assert.Null(result);
    }
    [Fact]
    public async Task AddUser_should_return_user_and_write_user_to_database()
    {
        //Arange
        await using var connection = new SqliteConnection("DataSource=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<RegisterDbContext>().UseSqlite(connection).Options;

        await using var context = new RegisterDbContext(options);

        await context.Database.EnsureCreatedAsync();

        var user = new global::User.Models.User(Name.Of("Hubert"), Email.Of("hubert@gmail.com"));

        var repository = new EFUserRepository(context);

        //Act
        var result = await repository.AddUser(user);
        var savedUser = await context.Users.FirstOrDefaultAsync(u => u.Email == Email.Of("hubert@gmail.com"));

        //Assert
        Assert.NotNull(result);
        Assert.Equal("Hubert", result.Name.Value);
        Assert.Equal("hubert@gmail.com", result.Email.Value);

        Assert.NotNull(savedUser);
        Assert.Equal("Hubert", savedUser.Name.Value);
        Assert.Equal("hubert@gmail.com", savedUser.Email.Value);
    }
}