using Domain.Commons;

namespace Domain.Entities.Flights;

public class Flight : Auditable
{
    public int FilghtNumber { get; set; }
    public string DepartureLocation { get; set; }
    public string Destination { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }
}
