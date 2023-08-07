using Domain.Commons;

namespace Domain.Entities.Passangers;

public class Passanger : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TelNumber { get; set; }
    public List<long> ListOfFlights { get; set; } = new List<long>();
    public string FlightDetail{ get; set; } = string.Empty;
    public string SeatInformation { get; set; } = string.Empty;
}
