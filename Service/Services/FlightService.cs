using Data.Constants;
using Domain.Entities.Flights;
using Newtonsoft.Json;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class FlightService : IFlightService
{
    public FlightService() 
    {
        string source = File.ReadAllText(FilePath.FLIGHT_PATH);

        if(string.IsNullOrEmpty(source))
            File.WriteAllText(FilePath.FLIGHT_PATH, "[]");
    }

    public async Task<Response<Flight>> CreateAsync(Flight flight)
    {
        string flightId = File.ReadAllText(FilePath.FLIGHT_ID_IDENTITY_PATH);

        if (string.IsNullOrEmpty(flightId))
            flightId = "1";

        flight.Id = long.Parse(flightId);

        List<Flight> flights = (await GetAllAsync()).Data.ToList();
        flights.Add(flight);

        string json = JsonConvert.SerializeObject(flights, Formatting.Indented);
        File.WriteAllText(FilePath.FLIGHT_PATH, json);
        File.WriteAllText(FilePath.FLIGHT_ID_IDENTITY_PATH, $"{flight.Id + 1}");

        return new Response<Flight>
        {
            StatusCode = 200,
            Message = "Success",
            Data = flight
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        List<Flight> flights = (await GetAllAsync()).Data.ToList();

        Flight existFlight = flights.FirstOrDefault(f => f.Id == id);

        if (existFlight is null)
            return new Response<bool> 
            { 
                StatusCode = 404,
                Message = "This flight not found",
                Data = false
            };

        flights.Remove(existFlight);
        
        string json = JsonConvert.SerializeObject(flights, Formatting.Indented);
        File.WriteAllText(FilePath.FLIGHT_PATH, json);

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<Flight>>> GetAllAsync()
    {
        string source = File.ReadAllText(FilePath.FLIGHT_PATH);

        IEnumerable<Flight> result = JsonConvert.DeserializeObject<IEnumerable<Flight>>(source);

        return new Response<IEnumerable<Flight>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<Flight>> GetByIdAsync(long id)
    {
        List<Flight> flights = (await GetAllAsync()).Data.ToList();

        Flight existFlight = flights.FirstOrDefault(f => f.Id == id);

        if (existFlight is null)
            return new Response<Flight>
            {
                StatusCode = 404,
                Message = "This flight not found",
                Data = existFlight
            };

        return new Response<Flight>
        {
            StatusCode = 200,
            Message = "Success",
            Data = existFlight
        };
    }

    public async Task<Response<Flight>> UpdateAsync(Flight flight)
    {
        List<Flight> flights = (await GetAllAsync()).Data.ToList();

        Flight existFlight = flights.FirstOrDefault(f => f.Id == flight.Id);

        if (existFlight is null)
            return new Response<Flight>
            {
                StatusCode = 404,
                Message = "This flight not found",
                Data = existFlight
            };

        existFlight.Id = flight.Id;
        existFlight.FilghtNumber = flight.FilghtNumber;
        existFlight.DepartureLocation = flight.DepartureLocation;
        existFlight.Destination = flight.Destination;
        existFlight.Date = flight.Date;
        existFlight.Time = flight.Time;
        existFlight.UpdateAt = DateTime.UtcNow;

        return new Response<Flight>
        {
            StatusCode = 200,
            Message = "Success",
            Data = existFlight
        };
    }
    public async Task<Response<IEnumerable<Flight>>> SearchByDepartureLocationAsync(string departureLocation)
    {
        List<Flight> flights = (await GetAllAsync()).Data.ToList();

        List<Flight> result = flights.Where(f => f.DepartureLocation.ToLower().Contains(departureLocation.ToLower())).ToList();

        return new Response<IEnumerable<Flight>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<IEnumerable<Flight>>> SearchByDestinationAsync(string destination)
    {
        List<Flight> flights = (await GetAllAsync()).Data.ToList();

        List<Flight> result = flights.Where(f => f.Destination.ToLower().Contains(destination.ToLower())).ToList();

        return new Response<IEnumerable<Flight>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<IEnumerable<Flight>>> SearchByDateAsync(DateTime dateTime)
    {
        List<Flight> flights = (await GetAllAsync()).Data.ToList();

        List<Flight> result = flights.Where(f => f.Date.Equals(dateTime)).ToList();

        return new Response<IEnumerable<Flight>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
