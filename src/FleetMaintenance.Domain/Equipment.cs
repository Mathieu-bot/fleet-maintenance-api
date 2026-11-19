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
            Guard.RequiredText(name, nameof(name), NameMaxLength),
            Guard.RequiredText(serialNumber, nameof(serialNumber), SerialNumberMaxLength),
            Guard.RequiredText(category, nameof(category), CategoryMaxLength),
            createdAt);
    }
}
