using WorkingDayCalculator.Application.DTOs;

namespace WorkingDayCalculator.Application.Services.Interfaces;

public interface IDayCalculatorService
{
    WorkingTimeDto GetWorkingTime(DateTime? date = null);
}
