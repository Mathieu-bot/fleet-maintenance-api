namespace FleetMaintenance.Domain.Common;

internal static class Guard
{
    public static string RequiredText(string value, string paramName, int maxLength)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, paramName);

        var trimmed = value.Trim();
        if (trimmed.Length > maxLength)
        {
            throw new ArgumentException($"Must be at most {maxLength} characters.", paramName);
        }

        return trimmed;
    }
}
