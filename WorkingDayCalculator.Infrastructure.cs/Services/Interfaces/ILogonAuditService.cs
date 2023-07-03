using WorkingDayCalculator.Infrastructure.DTOs;

namespace WorkingDayCalculator.Infrastructure.Services.Interfaces;

public interface ILogonAuditService
{
    IReadOnlyList<LogonAuditDto> GetLogins(DateTime? date = null);
    IReadOnlyList<LogonAuditDto> GetLogoffs(DateTime? date = null);
}
