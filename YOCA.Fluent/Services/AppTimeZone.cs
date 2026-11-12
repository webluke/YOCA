namespace YOCA.Fluent.Services;

public class AppTimeZone
{
    private readonly TimeZoneInfo _timeZone;

    public AppTimeZone(IConfiguration configuration)
    {
        var id = configuration["App:TimeZoneId"];
        _timeZone = Resolve(id);
    }

    public TimeZoneInfo TimeZone => _timeZone;

    public DateOnly Today() =>
        DateOnly.FromDateTime(TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, _timeZone));

    private static TimeZoneInfo Resolve(string? id)
    {
        if (!string.IsNullOrWhiteSpace(id))
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(id);
            }
            catch (TimeZoneNotFoundException)
            {
                // Fall through to defaults.
            }
            catch (InvalidTimeZoneException)
            {
                // Fall through to defaults.
            }
        }

        // Prefer IANA on Linux/macOS; Windows ID as secondary.
        foreach (var candidate in new[] { "America/Denver", "Mountain Standard Time" })
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById(candidate);
            }
            catch (TimeZoneNotFoundException)
            {
            }
            catch (InvalidTimeZoneException)
            {
            }
        }

        return TimeZoneInfo.Local;
    }
}
