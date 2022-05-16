namespace WebApi.Areas.SharedModels;

public record ConcreteCubeTestsInfoResponse
(
    Guid ConcreteCubeTestId,
    string ProtocolNumber,
    string CompanyName,
    string ConstructionSiteAddress,
    TestType TestType,
    DateTimeOffset TestExecutionDate,
    string TestExecutingUserName
);