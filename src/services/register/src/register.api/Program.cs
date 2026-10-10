using Register;
using Register.Data;
using User.Models;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Mapster;
using User.ValueObjects;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RegisterDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddValidatorsFromAssemblyContaining<ApplicationAssemblyMarker>();
builder.Services.AddMapster();
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));
builder.Services.AddTransient<IUserRepository, EFUserRepository>();
builder.Services.AddHttpClient("Register", c =>
c.BaseAddress = new Uri("https://localhost:7110"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// app.MapRazorPages();
app.MapControllers();
app.MapControllerRoute(
 name: "default",
 pattern: "{controller=RegisterUser}/{action=Create}");

app.Run();
