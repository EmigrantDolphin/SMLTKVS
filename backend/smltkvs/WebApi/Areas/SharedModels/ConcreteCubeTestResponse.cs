using System.Text.Json.Nodes;
using Laboratory.Domain.Aggregates;
using Mapster;

namespace WebApi.Areas.SharedModels;

public record ConcreteCubeTestResponse
{
    public Guid ConcreteCubeStrengthTestId { get; init; }
    public string TestProtocolNumber { get; init; }
    public Guid ClientCompanyId { get; init; }
    public CompanyResponse ClientCompany { get; init; }
    public Guid ClientConstructionSiteId { get; init; }
    public ConstructionSiteResponse ClientConstructionSite { get; init; }
    public Guid EmployeeCompanyId { get; init; }
    public DateTimeOffset TestExecutionDate { get; init; }
    public DateTimeOffset TestSamplesReceivedDate { get; init; }
    public string TestSamplesDeliveredBy { get; init; }
    public string TestSamplesReceivedComment { get; init; }
    public int TestSamplesReceivedCount { get; init; }
    public Guid TestExecutedByUserId { get; init; }
    public string? TestExecutedByUserName { get; init; }
    public Guid ProtocolCreatedByUserId { get; init; }
    public TestType TestType { get; init; }
    public ConcreteType ConcreteType { get; init; }
    public int AcceptedSampleCount { get; init; }
    public int RejectedSampleCount { get; init; }
    public decimal AverageCrushForce { get; init; }
    public decimal StandardUncertainty { get; init; }
    public decimal ExtendedUncertainty { get; init; }
    public decimal StandardDeviation { get; init; }
    public decimal CharacteristicStrength { get; init; }
    public string ConcreteRating { get; init; }

    public static ConcreteCubeTestResponse ToModel(ConcreteCubeStrengthTest data, string? testExecutedByUserName)
    {
        var response = data.Adapt<ConcreteCubeTestResponse>() with
        {
            TestExecutedByUserName = testExecutedByUserName,
            ClientConstructionSite = data.ClientCompany.ConstructionSites
                .Single(x => x.ConstructionSiteId == data.ClientConstructionSiteId)
                .Adapt<ConstructionSiteResponse>()
        };

        return response;
    }
}

public record CompanyResponse(
    Guid CompanyId,
    string Name,
    string Address,
    string CompanyCode
);

public record ConstructionSiteResponse(
    Guid ConstructionSiteId,
    string Name,
    string Address
);
