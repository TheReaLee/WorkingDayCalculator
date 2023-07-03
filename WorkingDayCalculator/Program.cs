using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WorkingDayCalculator.Application.Extensions;
using WorkingDayCalculator.Application.Services.Interfaces;
using WorkingDayCalculator.CNSLE.Extensions;

namespace WorkingDayCalculator;
public class Program
{
    public static void Main(string[] args)
    {
        var (serviceProvider, confiuration) = Configure(args);
        var currentDate = DateTime.Now;
        var dayCalculatorService = serviceProvider.GetRequiredService<IDayCalculatorService>();
        var workingTime = dayCalculatorService.GetWorkingTime(currentDate);

        Console.WriteLine($"{currentDate.ToString("dd-MM-yyyy")} - {workingTime.WorkingHours.ToHoursAndMinutesString()} - (Start: {workingTime.StartTime.ToHoursAndMinutesString()}, End: {workingTime.EndTime.ToHoursAndMinutesString()})");
        Console.ReadLine();
    }

    private static (IServiceProvider, IConfiguration) Configure(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.ConfigureApplication();

        var host = builder.Build();
        return (host.Services, builder.Configuration);
    }
}