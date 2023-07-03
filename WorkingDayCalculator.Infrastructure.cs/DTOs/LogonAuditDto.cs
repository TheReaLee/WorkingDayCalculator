using WorkingDayCalculator.Application.DTOs;

namespace WorkingDayCalculator.Infrastructure.DTOs;

public class LogonAuditDto
{
    private readonly string _username;
    private readonly DateTime _date;
    private readonly LogonAuditType _type;

    internal LogonAuditDto(string username, DateTime date, LogonAuditType type)
    {
        _username = username;
        _date = date;
        _type = type;
    }

    public string Username => _username;

    public DateTime Date => _date;

    public LogonAuditType Type => _type;
}