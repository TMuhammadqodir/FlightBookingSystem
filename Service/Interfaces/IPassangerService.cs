using Domain.Entities.Passangers;
using Service.Helpers;

namespace Service.Interfaces;

public interface IPassangerService
{
    Task<Response<Passanger>> CreateAsync(Passanger passanger);
    Task<Response<Passanger>> UpdateAsync(Passanger passanger);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<Passanger>> GetByIdAsync(long id);
    Task<Response<IEnumerable<Passanger>>> GetAllAsync();
    Task<Response<bool>> CancelBookingAsync(long passangerId, long id);
    Task<Response<Passanger>> BookingAsync(long passangerId,long id);
}
