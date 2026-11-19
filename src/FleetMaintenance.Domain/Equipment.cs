namespace FleetMaintenance.Domain;

public sealed class Equipment
{
    public const int NameMaxLength = 100;
    public const int SerialNumberMaxLength = 50;
    public const int CategoryMaxLength = 50;

    private Equipment(string name, string serialNumber, string category, DateTimeOffset createdAt)
    {
        Id = Guid.CreateVersion7();
        Name = name;
        SerialNumber = serialNumber;
        Category = category;
        Status = EquipmentStatus.Operational;
        CreatedAt = createdAt;
    }

    public Guid Id { get; }

    public string Name { get; }

    public string SerialNumber { get; }

    public string Category { get; }

    public EquipmentStatus Status { get; private set; }

    public DateTimeOffset CreatedAt { get; }

    public static Equipment Create(string name, string serialNumber, string category, DateTimeOffset createdAt)
    {
        return new Equipment(
            Normalize(name, nameof(name), NameMaxLength),
            Normalize(serialNumber, nameof(serialNumber), SerialNumberMaxLength),
            Normalize(category, nameof(category), CategoryMaxLength),
            createdAt);
    }

    private static string Normalize(string value, string paramName, int maxLength)
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
