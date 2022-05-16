using Laboratory.Domain.Entities.ConcreteCube;
using Laboratory.Domain.Enums;

namespace Laboratory.Domain.Aggregates;

public class ConcreteCubeStrengthTest
{
    public Guid ConcreteCubeStrengthTestId { get; private set; }
    public string TestProtocolNumber { get; private set; }
    public Guid ClientCompanyId { get; private set; }
    public Company ClientCompany { get; private set; }
    public Guid ClientConstructionSiteId { get; private set; }
    public Guid EmployeeCompanyId { get; private set; }
    public DateTimeOffset TestExecutionDate { get; private set; }
    public DateTimeOffset TestSamplesReceivedDate { get; private set; }
    public string TestSamplesDeliveredBy { get; private set; }
    public string TestSamplesReceivedComment { get; private set; }
    public int TestSamplesReceivedCount { get; private set; }
    public Guid TestExecutedByUserId { get; private set; }
    public Guid ProtocolCreatedByUserId { get; private set; }
    public TestType TestType { get; private set; }
    public ConcreteType ConcreteType { get; private set; }
    public int AcceptedSampleCount { get; private set; }
    public int RejectedSampleCount { get; private set; }
    public decimal AverageCrushForce { get; private set; }
    public decimal StandardUncertainty { get; private set; }
    public decimal ExtendedUncertainty { get; private set; }
    public decimal StandardDeviation { get; private set; }
    public decimal CharacteristicStrength { get; private set; }
    public string ConcreteRating { get; private set; }

    public List<ConcreteCubeStrengthTestData> TestData { get; private set; }

    public ConcreteCubeStrengthTest()
    {
        // For EFCore
    }
    public ConcreteCubeStrengthTest(
        string testProtocolNumber,
        Guid clientCompanyId,
        Guid clientConstructionSiteId,
        Guid employeeCompanyId,
        DateTimeOffset testExecutionDate,
        DateTimeOffset testSamplesReceivedDate,
        string testSamplesDeliveredBy,
        string testSamplesReceivedComment,
        int testSamplesReceivedCount,
        Guid testExecutedByUserId,
        Guid protocolCreatedByUserId,
        TestType testType,
        ConcreteType concreteType,
        int acceptedSampleCount,
        int rejectedSampleCount,
        decimal averageCrushForce,
        decimal standardUncertainty,
        decimal extendedUncertainty,
        decimal standardDeviation,
        decimal characteristicStrength,
        string concreteRating,
        List<ConcreteCubeStrengthTestData> testData
    )
    {
        ConcreteCubeStrengthTestId = Guid.NewGuid();
        TestProtocolNumber = testProtocolNumber;
        ClientCompanyId = clientCompanyId;
        ClientConstructionSiteId = clientConstructionSiteId;
        EmployeeCompanyId = employeeCompanyId;
        TestExecutionDate = testExecutionDate;
        TestSamplesReceivedDate = testSamplesReceivedDate;
        TestSamplesDeliveredBy = testSamplesDeliveredBy;
        TestSamplesReceivedComment = testSamplesReceivedComment;
        TestSamplesReceivedCount = testSamplesReceivedCount;
        TestExecutedByUserId = testExecutedByUserId;
        ProtocolCreatedByUserId = protocolCreatedByUserId;
        TestType = testType;
        ConcreteType = concreteType;
        AcceptedSampleCount = acceptedSampleCount;
        RejectedSampleCount = rejectedSampleCount;
        AverageCrushForce = averageCrushForce;
        StandardUncertainty = standardUncertainty;
        ExtendedUncertainty = extendedUncertainty;
        StandardDeviation = standardDeviation;
        CharacteristicStrength = characteristicStrength;
        ConcreteRating = concreteRating;
        TestData = testData;
    }
}