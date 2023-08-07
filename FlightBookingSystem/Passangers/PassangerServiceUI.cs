using Domain.Entities.Flights;
using Domain.Entities.Passangers;
using Service.Interfaces;
using Service.Services;

namespace FlightBookingSystem.Passangers;

public class PassangerServiceUI
{
    IPassangerService passangerService = new PassangerService();
    IFlightService flightService = new FlightService(); 
    public async Task CreateAsync()
    {
        await Console.Out.WriteAsync("FistName: ");
        string firstName = Console.ReadLine();
        await Console.Out.WriteAsync("LastName: ");
        string lastName = Console.ReadLine();
        await Console.Out.WriteAsync("TelNumber: ");
        string telNumber = Console.ReadLine();

        Passanger passanger = new Passanger()
        { 
            FirstName = firstName,
            LastName = lastName,
            TelNumber = telNumber
        };

        await passangerService.CreateAsync(passanger);

        await Console.Out.WriteLineAsync("Success");
    }

    public async Task DeleteAsync()
    {
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var check = await passangerService.DeleteAsync(id);

        if (check.StatusCode == 404)
            await Console.Out.WriteLineAsync("This passanger not found");
        else
            await Console.Out.WriteLineAsync("Success");
    }

    public async Task GetAllAsync()
    {
        List<Passanger> passangers = (await passangerService.GetAllAsync()).Data.ToList();

        foreach (var passanger in passangers)
        {
            await Console.Out.WriteLineAsync($"Id: {passanger.Id}\n" +
                                             $"FirstName: {passanger.FirstName}\n" +
                                             $"LastName:  {passanger.LastName}\n" +
                                             $"TelNumber:  {passanger.TelNumber}\n");
        }
    }

    public async Task GetByIdAsync()
    {
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var passanger = (await passangerService.GetByIdAsync(id)).Data;

        if (passanger is null)
            await Console.Out.WriteLineAsync("This passanger not found");
        else
        {
            await Console.Out.WriteLineAsync($"Id: {passanger.Id}\n" +
                                             $"FirstName: {passanger.FirstName}\n" +
                                             $"LastName:  {passanger.LastName}\n" +
                                             $"TelNumber:  {passanger.TelNumber}\n");
        }
    }
    public async Task UpdateAsync()
    {
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse(Console.ReadLine());
        await Console.Out.WriteAsync("FistName: ");
        string firstName = Console.ReadLine();
        await Console.Out.WriteAsync("LastName: ");
        string lastName = Console.ReadLine();
        await Console.Out.WriteAsync("TelNumber: ");
        string telNumber = Console.ReadLine();

        Passanger passanger = new Passanger()
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            TelNumber = telNumber
        };

        var temp = await passangerService.UpdateAsync(passanger);

        if (temp.StatusCode == 404)
            await Console.Out.WriteLineAsync("This passanger not found");
        else
            await Console.Out.WriteLineAsync("Success");
    }

    public async Task CancellingBookingAsync()
    {
        await Console.Out.WriteAsync("passangerId: ");
        long passangerId = long.Parse(Console.ReadLine());
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var check = await passangerService.CancelBookingAsync(passangerId, id);

        if (check.StatusCode == 404)
            await Console.Out.WriteLineAsync("This passanger not found");
        else
            await Console.Out.WriteLineAsync("Success");
    }

    public async Task BookingAsync()
    {
        await Console.Out.WriteAsync("passangerId: ");
        long passangerId = long.Parse(Console.ReadLine());
        await Console.Out.WriteAsync("Id: ");
        long id = long.Parse(Console.ReadLine());

        var temp = await flightService.GetByIdAsync(id);

        if (temp.StatusCode == 404)
            await Console.Out.WriteLineAsync("This flight not found");
        else
        {
            var check = await passangerService.CancelBookingAsync(passangerId, id);

            if (check.StatusCode == 404)
                await Console.Out.WriteLineAsync("This passanger not found");
            else
                await Console.Out.WriteLineAsync("Success");
        }
    }
}
