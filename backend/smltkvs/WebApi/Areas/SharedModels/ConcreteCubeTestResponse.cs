using System.Text.Json.Nodes;
using Laboratory.Domain.Aggregates;
using Laboratory.Domain.Entities.ConcreteCube;
using Laboratory.Domain.Enums;
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
    public List<TestDataResponse> TestData { get; init; }

    public static ConcreteCubeTestResponse ToModel(ConcreteCubeStrengthTest data, string? testExecutedByUserName)
    {
        var response = data.Adapt<ConcreteCubeTestResponse>() with
        {
            TestExecutedByUserName = testExecutedByUserName,
            TestData = TestDataResponse.ToModel(data.TestData),
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

public record TestDataResponse(
    Guid ConcreteCubeStrengthTestDataId,
    string Comment,
    decimal DestructivePower,
    decimal CrushingStrength,
    List<decimal> ValueA,
    List<decimal> ValueB
)
{
    public static List<TestDataResponse> ToModel(List<ConcreteCubeStrengthTestData> data)
    {
        var result = new List<TestDataResponse>();

        foreach (var item in data)
        {
            var aValues = item.Dimensions.Where(x => x.Dimension == CubeDimension.A).Select(x => x.Value).ToList();
            var bValues = item.Dimensions.Where(x => x.Dimension == CubeDimension.B).Select(x => x.Value).ToList();
            result.Add(new TestDataResponse(
                item.ConcreteCubeStrengthTestDataId,
                item.Comment,
                item.DestructivePower,
                item.CrushingStrength,
                aValues,
                bValues));
        }

        return result;
    }
};
