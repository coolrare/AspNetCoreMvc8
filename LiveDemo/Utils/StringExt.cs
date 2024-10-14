namespace LiveDemo.Utils;

public static class StringExt
{
    // Implement a extension methods for string to slug converter
    public static string ToSlug(this string input)
    {
        return input.ToLower().Replace(" ", "-");
    }
}
