using Room.Models;
using Book.Data;
using Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using FluentValidation;
using Mapster;
using Booking.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<BookDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
builder.Services.AddMapster();
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
builder.Services.AddTransient<IRoomRepository,RoomRepository>();
builder.Services.AddScoped<IBookingRepository,EFBookingRepository>();
builder.Services.AddScoped<IRoomsSeeder,RoomsSeeder>();
builder.Services.AddHttpClient("Booking", c =>
c.BaseAddress = new Uri("https://localhost:7125"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UsePathBase("/book");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// app.MapRazorPages();
app.MapControllers();

app.Run();
