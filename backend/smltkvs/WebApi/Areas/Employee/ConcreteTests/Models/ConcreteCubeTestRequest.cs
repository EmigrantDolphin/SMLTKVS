using System.ComponentModel.DataAnnotations;

namespace WebApi.Areas.Employee.ConcreteTests.Models;

public class ConcreteCubeTestRequest
{
    // public string TestProtocolNumber { get; set; }
    [Required]
    public Guid ClientCompanyId { get; set; }
    [Required]
    public Guid EmployeeCompanyId { get; set; }
    [Required]
    public DateTimeOffset TestExecutionDate { get; set; }
    [Required]
    public DateTimeOffset TestSamplesReceivedDate { get; set; }
    [Required]
    public string TestSamplesReceivedBy { get; set; }
    [Required]
    public string TestSamplesReceivedComment { get; set; }
    [Required]
    public int TestSamplesReceivedCount { get; set; }
    [Required]
    public Guid TestExecutedByUserId { get; set; }
    [Required]
    public Guid ProtocolCreatedByUserId { get; set; }
    [Required]
    public TestType TestType { get; set; }
    [Required]
    public ConcreteType ConcreteType { get; set; }
    [Required]
    public int AcceptedSampleCount { get; set; }
    [Required]
    public int RejectedSampleCount { get; set; }
    [Required]
    public decimal AverageCrushForce { get; set; }
    [Required]
    public decimal StandardUncertainty { get; set; }
    [Required]
    public decimal ExtendedUncertainty { get; set; }
    [Required]
    public decimal StandardDeviation { get; set; }
    [Required]
    public decimal CharacteristicStrength { get; set; }
    [Required]
    public string ConcreteRating { get; set; }
    [Required]
    public List<ConcreteCubeStrengthTestData> TestData { get; set; }
}

public class ConcreteCubeStrengthTestData
{
    public string? Comment { get; set; }
    [Required]
    public decimal DestructivePower { get; set; }
    [Required]
    public decimal CrushingStrength { get; set; }
    [Required]
    public decimal[] ValueA { get; set; }
    [Required]
    public decimal[] ValueB { get; set; }
}

public enum ConcreteType
{
    HeavyAndNormal = 0,
    Light = 1
}

public enum TestType
{
    Initial = 0,
    Permanent = 1
}