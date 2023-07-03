namespace WorkingDayCalculator.CNSLE.Extensions;

internal static class TimeSpanExtensions
{
    public static string ToHoursAndMinutesString(this TimeSpan timespan)
    {
        return $"{timespan.Hours}:{timespan.Minutes}";
    }
}
