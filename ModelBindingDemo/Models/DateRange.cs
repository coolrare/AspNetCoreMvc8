namespace ModelBindingDemo.Models;

public class DateRange
{
    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    public static bool TryParse(string input, out DateRange result)
    {
        result = null;
        if (string.IsNullOrEmpty(input))
        {
            return false;
        }

        // TODO: 這裡要避免例外發生

        var parts = input.Split('-');
        if (parts.Length != 2
            || !DateTime.TryParse(parts[0], out var start)
            || !DateTime.TryParse(parts[1], out var end))
        {
            return false;
        }

        result = new DateRange { Start = start, End = end };
        return true;
    }
}
