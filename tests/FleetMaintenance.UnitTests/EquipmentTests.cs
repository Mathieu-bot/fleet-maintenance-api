using FleetMaintenance.Domain;

namespace FleetMaintenance.UnitTests;

public class EquipmentTests
{
    private static readonly DateTimeOffset Now = new(2026, 11, 19, 8, 0, 0, TimeSpan.Zero);

    [Fact]
    public void Create_TrimsTextAndStartsOperational()
    {
        var equipment = Equipment.Create("  Excavator  ", " SN-001 ", " Heavy machinery ", Now);

        Assert.NotEqual(Guid.Empty, equipment.Id);
        Assert.Equal("Excavator", equipment.Name);
        Assert.Equal("SN-001", equipment.SerialNumber);
        Assert.Equal("Heavy machinery", equipment.Category);
        Assert.Equal(EquipmentStatus.Operational, equipment.Status);
        Assert.Equal(Now, equipment.CreatedAt);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_RejectsBlankName(string name)
    {
        Assert.Throws<ArgumentException>(nameof(name), () => Equipment.Create(name, "SN-001", "Heavy machinery", Now));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_RejectsBlankSerialNumber(string serialNumber)
    {
        Assert.Throws<ArgumentException>(nameof(serialNumber), () => Equipment.Create("Excavator", serialNumber, "Heavy machinery", Now));
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_RejectsBlankCategory(string category)
    {
        Assert.Throws<ArgumentException>(nameof(category), () => Equipment.Create("Excavator", "SN-001", category, Now));
    }

    [Fact]
    public void Create_RejectsNameLongerThanMaximum()
    {
        var tooLong = new string('a', Equipment.NameMaxLength + 1);

        Assert.Throws<ArgumentException>("name", () => Equipment.Create(tooLong, "SN-001", "Heavy machinery", Now));
    }
}
