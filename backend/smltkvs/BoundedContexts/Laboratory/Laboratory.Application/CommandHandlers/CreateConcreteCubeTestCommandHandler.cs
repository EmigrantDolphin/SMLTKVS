using Infrastructure.OneOf.Types;
using Laboratory.Application.Commands;
using Laboratory.Domain.Aggregates;
using Laboratory.Domain.Entities.ConcreteCube;
using Laboratory.Persistence;
using MediatR;
using OneOf;

namespace Laboratory.Application.CommandHandlers;

public class CreateConcreteCubeTestCommandHandler : IRequestHandler<CreateConcreteCubeTestCommand, OneOf<Success, BadRequest>>
{
    private readonly ILaboratoryContext _context;

    public CreateConcreteCubeTestCommandHandler(ILaboratoryContext context)
    {
        _context = context;
    }
    
    public async Task<OneOf<Success, BadRequest>> Handle(CreateConcreteCubeTestCommand request, CancellationToken cancellationToken)
    {
        var concreteCubeStrengthTestData = request.TestData.Select(x =>
            new ConcreteCubeStrengthTestData(
                x.Comment,
                x.DestructivePower,
                x.CrushingStrength,
                CrossSectionalDimensions.ToDomain(x.ValueA, x.ValueB)
            )
        ).ToList();

        var concreteCubeStrengthTest = new ConcreteCubeStrengthTest(
            "protocolNumber",
            request.ClientCompanyId,
            request.EmployeeCompanyId,
            request.TestExecutionDate,
            request.TestSamplesReceivedDate,
            request.TestSamplesReceivedBy,
            request.TestSamplesReceivedComment,
            request.TestSamplesReceivedCount,
            request.TestExecutedByUserId,
            request.ProtocolCreatedByUserId,
            request.TestType,
            request.ConcreteType,
            request.AcceptedSampleCount,
            request.RejectedSampleCount,
            request.AverageCrushForce,
            request.StandardUncertainty,
            request.ExtendedUncertainty,
            request.StandardDeviation,
            request.CharacteristicStrength,
            request.ConcreteRating,
            concreteCubeStrengthTestData);

        _context.ConcreteCubeStrengthTests.Add(concreteCubeStrengthTest);
        await _context.SaveChangesAsync();

        return new Success();
    }
}