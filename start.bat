@echo off

set "ROOT=%cd%"

start "Register.Api" cmd /k dotnet run --project "%ROOT%\src\services\Register\src\Register.Api\Register.Api.csproj" --no-build

start "Booking.Api" cmd /k dotnet run --project "%ROOT%\src\services\Book\src\Book.Api\Book.Api.csproj" --no-build

start "" "https://localhost:7110"