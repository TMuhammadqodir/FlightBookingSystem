using Domain.Entities.Flights;
using Service.Interfaces;
using Service.Services;

namespace FlightBookingSystem.Flights;

public class FlightServiceUI
{
    IFlightService flightService = new FlightService();
    public async Task CreateAsync()
    {
        await Console.Out.WriteAsync("FlightNumber: ");
        int filghtNumber = int.Parse(Console.ReadLine());
        await Console.Out.WriteAsync("DepartureLocation: ");
        string departureLocation = Console.ReadLine();
        await Console.Out.WriteAsync("Destanation: ");
        string destination = Console.ReadLine();
        await Console.Out.WriteAsync("Date (dd-mm-yyyy): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        await Console.Out.WriteAsync("Time (hh:mm): ");
        string time = Console.ReadLine();

        Flight flight = new Flight() 
        { 
            FilghtNumber = filghtNumber,
            DepartureLocation = departureLocation,
            Destination = destination,
            Date = date,
            Time = time
        };

        await flightService.CreateAsync(flight);

        await Console.Out.WriteLineAsync("Success");
    }

    public async Task DeleteAsync()
    {
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var check = await flightService.DeleteAsync(id);

        if(check.StatusCode == 404)
            await Console.Out.WriteLineAsync("This flight not found");
        else
            await Console.Out.WriteLineAsync("Success");
    }

    public async Task GetAllAsync()
    {
        List<Flight> flights = (await flightService.GetAllAsync()).Data.ToList();

        foreach(var flight in flights)
        {
            await Console.Out.WriteLineAsync($"Id: {flight.Id}\n" +
                                             $"FlightNumber: {flight.FilghtNumber}\n" +
                                             $"DepartureLocation: {flight.DepartureLocation}\n" +
                                             $"Destination: {flight.Destination}\n" +
                                             $"Date: {flight.Date}\n" +
                                             $"Time: {flight.Time}\n" +
                                             $"CreateAt {flight.CreateAt}\n" +
                                             $"UpdateAt {flight.UpdateAt}\n");
        }
    }

    public async Task GetByIdAsync()
    {
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var flight = (await flightService.GetByIdAsync(id)).Data;

        if(flight is null)
            await Console.Out.WriteLineAsync("This flight not found");
        else
        {
            await Console.Out.WriteLineAsync($"Id: {flight.Id}\n" +
                                 $"FlightNumber: {flight.FilghtNumber}\n" +
                                 $"DepartureLocation: {flight.DepartureLocation}\n" +
                                 $"Destination: {flight.Destination}\n" +
                                 $"Date: {flight.Date}\n" +
                                 $"Time: {flight.Time}\n" +
                                 $"CreateAt {flight.CreateAt}\n" +
                                 $"UpdateAt {flight.UpdateAt}");
        }
    }

    public async Task SearchByDepartureLocationAsync()
    {
        await Console.Out.WriteLineAsync("Search word: ");
        string word = Console.ReadLine();

        var flights = (await flightService.SearchByDepartureLocationAsync(word)).Data;

        foreach (var flight in flights)
        {
            await Console.Out.WriteLineAsync($"Id: {flight.Id}\n" +
                                 $"FlightNumber: {flight.FilghtNumber}\n" +
                                 $"DepartureLocation: {flight.DepartureLocation}\n" +
                                 $"Destination: {flight.Destination}\n" +
                                 $"Date: {flight.Date}\n" +
                                 $"Time: {flight.Time}\n" +
                                 $"CreateAt {flight.CreateAt}\n" +
                                 $"UpdateAt {flight.UpdateAt}");
        }
    }

    public async Task UpdateAsync()
    {
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse( Console.ReadLine());
        await Console.Out.WriteAsync("FlightNumber: ");
        int filghtNumber = int.Parse(Console.ReadLine());
        await Console.Out.WriteAsync("DepartureLocation: ");
        string departureLocation = Console.ReadLine();
        await Console.Out.WriteAsync("Destanation: ");
        string destination = Console.ReadLine();
        await Console.Out.WriteAsync("Date (dd-mm-yyyy): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        await Console.Out.WriteAsync("Time (hh:mm): ");
        string time = Console.ReadLine();

        Flight flight = new Flight()
        {
            Id = id,
            FilghtNumber = filghtNumber,
            DepartureLocation = departureLocation,
            Destination = destination,
            Date = date,
            Time = time
        };

        var temp =await flightService.UpdateAsync(flight);

        if(temp.StatusCode == 404)
            await Console.Out.WriteLineAsync("This flight not found");
        else
            await Console.Out.WriteLineAsync("Success");
    }

    public async Task SearchByDestinayionAsync()
    {
        await Console.Out.WriteLineAsync("Search word: ");
        string word = Console.ReadLine();

        var flights = (await flightService.SearchByDestinationAsync(word)).Data;

        foreach (var flight in flights)
        {
            await Console.Out.WriteLineAsync($"Id: {flight.Id}\n" +
                                 $"FlightNumber: {flight.FilghtNumber}\n" +
                                 $"DepartureLocation: {flight.DepartureLocation}\n" +
                                 $"Destination: {flight.Destination}\n" +
                                 $"Date: {flight.Date}\n" +
                                 $"Time: {flight.Time}\n" +
                                 $"CreateAt {flight.CreateAt}\n" +
                                 $"UpdateAt {flight.UpdateAt}");
        }
    }

    public async Task SearchByDateAsync()
    {
        await Console.Out.WriteLineAsync("Search date: ");
        DateTime date = DateTime.Parse(Console.ReadLine());

        var flights = (await flightService.SearchByDateAsync(date)).Data;

        foreach (var flight in flights)
        {
            await Console.Out.WriteLineAsync($"Id: {flight.Id}\n" +
                                 $"FlightNumber: {flight.FilghtNumber}\n" +
                                 $"DepartureLocation: {flight.DepartureLocation}\n" +
                                 $"Destination: {flight.Destination}\n" +
                                 $"Date: {flight.Date}\n" +
                                 $"Time: {flight.Time}\n" +
                                 $"CreateAt {flight.CreateAt}\n" +
                                 $"UpdateAt {flight.UpdateAt}");
        }
    }
}