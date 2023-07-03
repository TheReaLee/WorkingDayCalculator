namespace WorkingDayCalculator.Application.DTOs;

public class WorkingTimeDto
{
    private readonly TimeSpan _startTime;
    private readonly TimeSpan _endTime;
    private readonly TimeSpan _workingHours;

    internal WorkingTimeDto(TimeSpan startTime, TimeSpan endTime, TimeSpan workingHours)
    {
        this._startTime = startTime;
        this._endTime = endTime;
        this._workingHours = workingHours;
    }

    public TimeSpan StartTime => _startTime;

    public TimeSpan EndTime => _endTime;

    public TimeSpan WorkingHours => _workingHours;
}
