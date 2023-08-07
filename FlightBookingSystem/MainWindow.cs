using FlightBookingSystem.Flights;
using FlightBookingSystem.Passangers;

namespace FlightBookingSystem;

public class MainWindow
{
    FlightServiceUI flightServiceUI = new FlightServiceUI();
    PassangerServiceUI PassangerServiceUI = new PassangerServiceUI();
    public MainWindow() 
    {
        Console.WriteLine("1. Flight\n" +
                          "2. Passanger");

        Console.Write(">>>> ");

        int n = int.Parse(Console.ReadLine());

        switch (n)
        {
            case 1:
                FlighControl();
                break;  

            case 2: 
                PassangerControl();
                break;
            
            default: 
                MainWindow mainWindow = new MainWindow();
                break;
        }
    }

    public async Task FlighControl()
    {
        while (true)
        {
            Console.WriteLine("1. Create\n" +
                              "2. Update\n" +
                              "3. Delete\n" +
                              "4. GetById\n" +
                              "5. GetAll\n" +
                              "6. SearchByDepartureLocation\n" +
                              "7. SearchByDestination\n" +
                              "8. SearchByDate\n" +
                              "9.Back");

            Console.Write(">>>> ");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    await flightServiceUI.CreateAsync();
                    break;

                case 2:
                    await flightServiceUI.UpdateAsync();
                    break;

                case 3:
                    await flightServiceUI.DeleteAsync();
                    break;

                case 4:
                    await flightServiceUI.GetByIdAsync();
                    break;

                case 5:
                    await flightServiceUI.GetAllAsync();
                    break;

                case 6:
                    await flightServiceUI.SearchByDepartureLocationAsync();
                    break;

                case 7:
                    await flightServiceUI.SearchByDestinayionAsync();
                    break;

                case 8:
                    await flightServiceUI.SearchByDateAsync();
                    break;

                case 9:
                    MainWindow mainWindow = new MainWindow();
                    break;

                default:
                    await FlighControl();
                    break;
            }
        }
    }

    public async Task PassangerControl()
    {
        while (true)
        {
            Console.WriteLine("1. Create\n" +
                              "2. Update\n" +
                              "3. Delete\n" +
                              "4. GetById\n" +
                              "5. GetAll\n" +
                              "6. Booking\n" +
                              "7. CancelBooking\n" +
                              "8.Back");

            Console.Write(">>>> ");
            int n = int.Parse(Console.ReadLine());

            switch (n)
            {
                case 1:
                    await PassangerServiceUI.CreateAsync();
                    break;

                case 2:
                    await PassangerServiceUI.UpdateAsync();
                    break;

                case 3:
                    await PassangerServiceUI.DeleteAsync();
                    break;

                case 4:
                    await PassangerServiceUI.GetByIdAsync();
                    break;

                case 5:
                    await PassangerServiceUI.GetAllAsync();
                    break;

                case 6:
                    await PassangerServiceUI.BookingAsync();
                    break;

                case 7:
                    await PassangerServiceUI.CancellingBookingAsync();
                    break;

                case 8:
                    MainWindow mainWindow = new MainWindow();
                    break;

                default:
                    await PassangerControl();
                    break;
            }
        }
    }
}
