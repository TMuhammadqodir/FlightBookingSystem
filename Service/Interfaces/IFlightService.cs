using Domain.Entities.Flights;
using Service.Helpers;

namespace Service.Interfaces;

public interface IFlightService
{
    Task<Response<Flight>> CreateAsync(Flight flight);
    Task<Response<Flight>> UpdateAsync(Flight flight);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<Flight>> GetByIdAsync(long id);
    Task<Response<IEnumerable<Flight>>> GetAllAsync();
    Task<Response<IEnumerable<Flight>>> SearchByDepartureLocationAsync(string departureLocation);
    Task<Response<IEnumerable<Flight>>> SearchByDestinationAsync(string destination);
    Task<Response<IEnumerable<Flight>>> SearchByDateAsync(DateTime dateTime);
}
