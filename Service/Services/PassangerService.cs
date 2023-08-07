using Data.Constants;
using Domain.Entities.Flights;
using Domain.Entities.Passangers;
using Newtonsoft.Json;
using Service.Helpers;
using Service.Interfaces;

namespace Service.Services;

public class PassangerService : IPassangerService
{
    public PassangerService() 
    {
        string source = File.ReadAllText(FilePath.PASSANGER_PATH);

        if (string.IsNullOrEmpty(source))
            File.WriteAllText(FilePath.PASSANGER_PATH, "[]");
    }

    public async Task<Response<Passanger>> BookingAsync(long passangerId, long id)
    {
        List<Passanger> passangers = (await GetAllAsync()).Data.ToList();

        Passanger existPassanger = passangers.FirstOrDefault(p => p.Id == passangerId);

        if (existPassanger is null)
            return new Response<Passanger>
            {
                StatusCode = 404,
                Message = "This flight not found",
                Data = existPassanger
            };

        existPassanger.ListOfFlights.Add(id);

        string json = JsonConvert.SerializeObject(existPassanger, Formatting.Indented);
        File.WriteAllText(FilePath.PASSANGER_PATH, json);

        return new Response<Passanger>
        {
            StatusCode = 200,
            Message = "Success",
            Data = existPassanger
        };
    }

    public async Task<Response<bool>> CancelBookingAsync(long passangerId, long id)
    {
        List<Passanger> passangers = (await GetAllAsync()).Data.ToList();

        Passanger existPassanger = passangers.FirstOrDefault(p=>p.Id == passangerId);

        if (existPassanger is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "This flight not found",
                Data = false
            };

        if (existPassanger.ListOfFlights.Contains(id) == false)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "This flight not found",
                Data = false
            };

        existPassanger.ListOfFlights.Remove(id);

        string json = JsonConvert.SerializeObject(existPassanger, Formatting.Indented);
        File.WriteAllText(FilePath.PASSANGER_PATH, json);

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<Passanger>> CreateAsync(Passanger passanger)
    {
        string passangerId = File.ReadAllText(FilePath.PASSANGER_ID_IDENTITY_PATH);

        if (string.IsNullOrEmpty(passangerId))
            passangerId = "1";

        passanger.Id = long.Parse(passangerId);

        List<Passanger> passangers = (await GetAllAsync()).Data.ToList();
        passangers.Add(passanger);

        string json = JsonConvert.SerializeObject(passangers, Formatting.Indented);
        File.WriteAllText(FilePath.PASSANGER_PATH, json);
        File.WriteAllText(FilePath.PASSANGER_ID_IDENTITY_PATH, $"{passanger.Id + 1}");

        return new Response<Passanger>
        {
            StatusCode = 200,
            Message = "Success",
            Data = passanger
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        List<Passanger> passangers = (await GetAllAsync()).Data.ToList();

        Passanger existPassanger = passangers.FirstOrDefault(f => f.Id == id);

        if (existPassanger is null)
            return new Response<bool>
            {
                StatusCode = 404,
                Message = "This passanger not found",
                Data = false
            };

        passangers.Remove(existPassanger);

        string json = JsonConvert.SerializeObject(passangers, Formatting.Indented);
        File.WriteAllText(FilePath.PASSANGER_PATH, json);

        return new Response<bool>
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<IEnumerable<Passanger>>> GetAllAsync()
    {
        string source = File.ReadAllText(FilePath.PASSANGER_PATH);

        IEnumerable<Passanger> result = JsonConvert.DeserializeObject<IEnumerable<Passanger>>(source);

        return new Response<IEnumerable<Passanger>>
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<Passanger>> GetByIdAsync(long id)
    {
        List<Passanger> passangers = (await GetAllAsync()).Data.ToList();

        Passanger existPassanger = passangers.FirstOrDefault(f => f.Id == id);

        if (existPassanger is null)
            return new Response<Passanger>
            {
                StatusCode = 404,
                Message = "This passanger not found",
                Data = existPassanger
            };

        return new Response<Passanger>
        {
            StatusCode = 200,
            Message = "Success",
            Data = existPassanger
        };
    }

    public async Task<Response<Passanger>> UpdateAsync(Passanger passanger)
    {
        List<Passanger> passangers = (await GetAllAsync()).Data.ToList();

        Passanger existPassanger = passangers.FirstOrDefault(f => f.Id == passanger.Id);

        if (existPassanger is null)
            return new Response<Passanger>
            {
                StatusCode = 404,
                Message = "This passanger not found",
                Data = existPassanger
            };

        existPassanger.Id = passanger.Id;
        existPassanger.FirstName = passanger.FirstName;
        existPassanger.LastName = passanger.LastName;
        existPassanger.TelNumber = passanger.TelNumber;
        existPassanger.ListOfFlights = passanger.ListOfFlights;
        existPassanger.FlightDetail = passanger.FlightDetail;
        existPassanger.SeatInformation = passanger.SeatInformation;
        existPassanger.UpdateAt = DateTime.UtcNow;

        string json = JsonConvert.SerializeObject(existPassanger, Formatting.Indented);
        File.WriteAllText(FilePath.PASSANGER_PATH, json);
        
        return new Response<Passanger>
        {
            StatusCode = 200,
            Message = "Success",
            Data = existPassanger
        };
    }
}
