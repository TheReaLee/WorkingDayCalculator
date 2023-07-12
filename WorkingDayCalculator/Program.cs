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

        if (args.Any() && args[0].ToLower() == "week")
        {
            var dates = GetWorkingDates(currentDate);
            foreach (var date in dates)
            {
                var workingTime = dayCalculatorService.GetWorkingTime(date);
                Console.WriteLine($"{date.ToString("dd-MM-yyyy")} - {workingTime.WorkingHours.ToHoursAndMinutesString()} - (Start: {workingTime.StartTime.ToHoursAndMinutesString()}, End: {workingTime.EndTime.ToHoursAndMinutesString()})");
            }
        }

        var startWorkingDay = dayCalculatorService.GetWorkingTime(currentDate);
        Console.WriteLine($"{currentDate.ToString("dd-MM-yyyy")} - {startWorkingDay.WorkingHours.ToHoursAndMinutesString()} - (Start: {startWorkingDay.StartTime.ToHoursAndMinutesString()}, End: {startWorkingDay.EndTime.ToHoursAndMinutesString()})");

        Console.ReadLine();
    }

    private static List<DateTime> GetWorkingDates(DateTime startDate)
    {
        var workingDates = new List<DateTime>();
        var totalDates = startDate.DayOfWeek - DayOfWeek.Monday;
        for (var i = totalDates; i > 0; i--)
            workingDates.Add(startDate.AddDays(-i));

        return workingDates;
    }

    private static (IServiceProvider, IConfiguration) Configure(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.ConfigureApplication();

        var host = builder.Build();
        return (host.Services, builder.Configuration);
    }
}