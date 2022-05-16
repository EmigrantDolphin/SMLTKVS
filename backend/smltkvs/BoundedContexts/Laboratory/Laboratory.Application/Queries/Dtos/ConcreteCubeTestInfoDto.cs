using Laboratory.Domain.Enums;

namespace Laboratory.Application.Queries.Dtos;
public record ConcreteCubeTestInfoDto(
    Guid ConcreteCubeTestId,
    string ProtocolNumber,
    string CompanyName,
    string ConstructionSiteAddress,
    TestType TestType,
    DateTimeOffset TestExecutionDate,
    Guid ExecutingUserId
);