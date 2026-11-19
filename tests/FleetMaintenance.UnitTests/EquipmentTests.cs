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

    [Fact]
    public void Create_RejectsSerialNumberLongerThanMaximum()
    {
        var tooLong = new string('a', Equipment.SerialNumberMaxLength + 1);

        Assert.Throws<ArgumentException>("serialNumber", () => Equipment.Create("Excavator", tooLong, "Heavy machinery", Now));
    }

    [Fact]
    public void Create_RejectsCategoryLongerThanMaximum()
    {
        var tooLong = new string('a', Equipment.CategoryMaxLength + 1);

        Assert.Throws<ArgumentException>("category", () => Equipment.Create("Excavator", "SN-001", tooLong, Now));
    }

    [Fact]
    public void Create_AcceptsTextsOfExactlyTheMaximumLength()
    {
        var name = new string('a', Equipment.NameMaxLength);
        var serialNumber = new string('b', Equipment.SerialNumberMaxLength);
        var category = new string('c', Equipment.CategoryMaxLength);

        var equipment = Equipment.Create(name, serialNumber, category, Now);

        Assert.Equal(name, equipment.Name);
        Assert.Equal(serialNumber, equipment.SerialNumber);
        Assert.Equal(category, equipment.Category);
    }
}
