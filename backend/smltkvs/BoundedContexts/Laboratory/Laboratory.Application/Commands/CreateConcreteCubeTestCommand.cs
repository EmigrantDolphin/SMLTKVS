using Infrastructure.OneOf.Types;
using Laboratory.Domain.Enums;
using MediatR;
using OneOf;

namespace Laboratory.Application.Commands;

public record CreateConcreteCubeTestCommand(
        Guid ClientCompanyId,
        Guid ClientConstructionSiteId,
        Guid EmployeeCompanyId,
        DateTimeOffset TestExecutionDate,
        DateTimeOffset TestSamplesReceivedDate,
        string TestSamplesDeliveredBy,
        string TestSamplesReceivedComment,
        int TestSamplesReceivedCount,
        Guid TestExecutedByUserId,
        Guid ProtocolCreatedByUserId,
        TestType TestType,
        ConcreteType ConcreteType,
        int AcceptedSampleCount,
        int RejectedSampleCount,
        decimal AverageCrushForce,
        decimal StandardUncertainty,
        decimal ExtendedUncertainty,
        decimal StandardDeviation,
        decimal CharacteristicStrength,
        string ConcreteRating,
        List<ConcreteCubeStrengthTestCommandData> TestData
    ) : IRequest<OneOf<Success, BadRequest>>;
    
public record ConcreteCubeStrengthTestCommandData(
        string Comment,
        decimal DestructivePower,
        decimal CrushingStrength,
        decimal[] ValueA,
        decimal[] ValueB
    );