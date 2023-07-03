using System.Diagnostics;
using WorkingDayCalculator.Application.DTOs;
using WorkingDayCalculator.Infrastructure.DTOs;
using WorkingDayCalculator.Infrastructure.Services.Interfaces;

namespace WorkingDayCalculator.Application.Services;

internal class LogonAuditService : ILogonAuditService
{
    private const string Type = "Security";
    private const string Source = "Microsoft-Windows-Security-Auditing";
    private readonly EventLog _eventLog;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Target machine is Windows")]
    public LogonAuditService()
    {
        _eventLog = new EventLog(Type);
    }

    public IReadOnlyList<LogonAuditDto> GetLogins(DateTime? date = null) => Get(LogonAuditType.Logoff, date);

    public IReadOnlyList<LogonAuditDto> GetLogoffs(DateTime? date = null) => Get(LogonAuditType.Logon, date);

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Target machine is Windows")]
    private IReadOnlyList<LogonAuditDto> Get(LogonAuditType type, DateTime? date = null)
    {
        var dateFilter = date.HasValue ? date.Value : DateTime.Now;
        var startDateFilter = new DateTime(dateFilter.Year, dateFilter.Month, dateFilter.Day, 00, 00, 01);
        var endDateFilter = new DateTime(dateFilter.Year, dateFilter.Month, dateFilter.Day, 23, 59, 59);

        var logins = _eventLog.Entries.Cast<EventLogEntry>()
            .Where(x => x.InstanceId == (int)LogonAuditType.Logon
            && x.Source == Source
            && (x.TimeGenerated >= startDateFilter && x.TimeGenerated <= endDateFilter));

        return logins.Select(x => new LogonAuditDto(
            x.UserName,
            x.TimeGenerated,
            LogonAuditType.Logon)
        ).OrderBy(x => x.Date).ToList();
    }
}
