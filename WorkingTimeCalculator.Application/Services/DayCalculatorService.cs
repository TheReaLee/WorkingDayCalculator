using WorkingDayCalculator.Application.DTOs;
using WorkingDayCalculator.Application.Services.Interfaces;
using WorkingDayCalculator.Infrastructure.Services.Interfaces;

namespace WorkingDayCalculator.Application.Services;

internal class DayCalculatorService : IDayCalculatorService
{
    private readonly ILogonAuditService _logonAuditService;
    public DayCalculatorService(ILogonAuditService eventLogService)
    {
        _logonAuditService = eventLogService;
    }

    public WorkingTimeDto GetWorkingTime(DateTime? date = null)
    {
        var loginTime = _logonAuditService.GetLogins(date).First().Date.TimeOfDay;
        var endTimeOfDay = date.HasValue ? date.Value.TimeOfDay : DateTime.Now.TimeOfDay;

        return new WorkingTimeDto(loginTime, endTimeOfDay, endTimeOfDay - loginTime);
    }
}
